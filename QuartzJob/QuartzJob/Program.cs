using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzJob
{
    class Program
    {
        static  void Main(string[] args)
        {

            Run();
            Console.ReadLine();

        }


        static async void Run()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();

            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<HiFiveJob>().Build();


            ITrigger trigger = TriggerBuilder.Create()
            .WithDailyTimeIntervalSchedule
              (s =>
                 s
                .WithIntervalInMinutes(1) 
                .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(16, 50))
              )
            .Build();

            scheduler.ScheduleJob(job, trigger);

        }
    }

    class HiFiveJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                var now = DateTime.Now;
                Console.WriteLine($"Job is executed at {now}");
            });
           
        }
    }
}
