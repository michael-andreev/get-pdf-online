using PrecizeSoft.GetPdfOnline.Data;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Schedulers
{
    internal class DeleteExpiredDataJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            ICacheRepository repository = (ICacheRepository)context.JobDetail.JobDataMap["CacheRepository"];

            repository.DeleteExpiredData();

            return Task.CompletedTask;
        }
    }
}
