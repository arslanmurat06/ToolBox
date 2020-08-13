using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ProducerConsumerPerformances
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SingleJobBenchmark>();

            Console.ReadLine();
        }
    }

    public class BlockingCollectionQueue : IJobQueue<Action>
    {
        private BlockingCollection<Action> _jobs = new BlockingCollection<Action>();

        public BlockingCollectionQueue()
        {
            var thread = new Thread(new ThreadStart(OnStart));
            thread.IsBackground = true;
            thread.Start();
        }

        public void Enqueue(Action job)
        {
            _jobs.Add(job);
        }

        private void OnStart()
        {
            foreach (var job in _jobs.GetConsumingEnumerable(CancellationToken.None))
            {
                job.Invoke();
            }
        }

        public void Stop()
        {
            _jobs.CompleteAdding();
        }
    }

    public class ChannelsQueue : IJobQueue<Action>
    {
        private ChannelWriter<Action> _writer;

        public ChannelsQueue()
        {
            var channel = Channel.CreateUnbounded<Action>(new UnboundedChannelOptions() { SingleReader = true });
            var reader = channel.Reader;
            _writer = channel.Writer;

            Task.Run(async () =>
            {
                while (await reader.WaitToReadAsync())
                {
                    // Fast loop around available jobs
                    while (reader.TryRead(out var job))
                    {
                        job.Invoke();
                    }
                }
            });
        }

        public void Enqueue(Action job)
        {
            _writer.TryWrite(job);
        }

        public void Stop()
        {
            _writer.Complete();
        }
    }

    public class SingleJobBenchmark
    {
        private AutoResetEvent _autoResetEvent;

        public SingleJobBenchmark()
        {
            _autoResetEvent = new AutoResetEvent(false);
        }

        [Benchmark]
        public void BlockingCollectionQueue()
        {
            DoOneJob(new BlockingCollectionQueue());
        }
      
        [Benchmark]
        public void ChannelsQueue()
        {
            DoOneJob(new ChannelsQueue());
        }
       

        private void DoOneJob(IJobQueue<Action> jobQueue)
        {
            jobQueue.Enqueue(() => _autoResetEvent.Set());
            _autoResetEvent.WaitOne();
            jobQueue.Stop();
        }
    }
}
