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

            IJobDetail job = JobBuilder.Create<HiFiveJob>()
                .WithIdentity("myJob","group1")
                .Build();


            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("myTrigger","group1")    
            .WithDailyTimeIntervalSchedule
              (s =>
                 s
                .WithIntervalInMinutes(1) 
                .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(8, 50))
              )
              .EndAt(DateBuilder.DateOf(9, 15, 0, 4, 7, 2019))
              .ForJob("myJob","group1")
            .Build();

            TriggerKey key = new TriggerKey("myTrigger", "group1");

            if (await scheduler.GetTriggerState(key) == TriggerState.Complete)
            {
                Console.WriteLine("Job completed");
            }

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
