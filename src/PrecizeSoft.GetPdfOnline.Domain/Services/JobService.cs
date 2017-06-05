using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Converters;
using PrecizeSoft.IO.Contracts.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Services
{
    public class JobService : IJobService
    {
        protected ICacheRepository cacheRepository;

        public JobService(ICacheRepository cacheRepository)
        {
            this.cacheRepository = cacheRepository;
        }

        public void AddJob(IJob job)
        {
            this.cacheRepository.CreateJob(job.ToConvertJob(), true);
        }

        public void EditJob(Guid jobId, byte? rating)
        {
            this.cacheRepository.UpdateJob(jobId, rating);
        }

        public IJob GetJob(Guid jobId)
        {
            return this.cacheRepository.GetJob(jobId)?.ToJob();
        }

        public IEnumerable<IJob> GetJobsBySession(Guid sessionId)
        {
            return this.cacheRepository.GetJobsBySession(sessionId).Select(p => p.ToJob()).ToList();
        }

        public void DeleteSession(Guid sessionId)
        {
            this.cacheRepository.DeleteSession(sessionId);
        }

        public bool SessionExists(Guid sessionId)
        {
            return this.cacheRepository.SessionExists(sessionId);
        }
    }
}
