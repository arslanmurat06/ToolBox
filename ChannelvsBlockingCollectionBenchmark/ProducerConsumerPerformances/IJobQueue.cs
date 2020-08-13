using System;

namespace ProducerConsumerPerformances
{
    public interface IJobQueue<T>
    {
        void Enqueue(Action job);
        void Stop();
    }
}