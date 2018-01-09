using PrecizeSoft.GetPdfOnline.Data;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Schedulers
{
    public static class DeleteExpiredDataScheduler
    {
        public static async Task Start(ICacheRepository cacheRepository)
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IDictionary<string, object> jobData = new Dictionary<string, object>();
            jobData.Add("CacheRepository", cacheRepository);

            IJobDetail job = JobBuilder.Create<DeleteExpiredDataJob>()
                .SetJobData(new JobDataMap(jobData)).Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("DeleteExpiredDataTrigger", "GetPdfOnline")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(1)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
