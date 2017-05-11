using System;
using System.Collections.Generic;
using System.Text;
using PrecizeSoft.GetPdfOnline.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Repositories
{
    public class CacheRepository : ICacheRepository
    {
        public CacheDbContext context;

        public CacheRepository(CacheDbContext dbContext)
        {
            this.context = dbContext;
        }

        public void CreateFile(BinaryFile file)
        {
            this.context.BinaryFiles.Add(file);
            this.context.SaveChanges();
        }

        public void CreateJob(ConvertJob job)
        {
            this.context.ConvertJobs.Add(job);
            this.context.SaveChanges();
        }

        public BinaryFile GetFile(Guid fileId, bool includeContent = false)
        {
            IQueryable<BinaryFile> q = this.context.BinaryFiles;

            if (includeContent)
            {
                q = q.Include(c => c.Content);
            }

            return q.Where(p => p.FileId == fileId).SingleOrDefault();
        }

        public IEnumerable<BinaryFile> GetFiles(IEnumerable<Guid> fileIds)
        {
            return this.context.BinaryFiles.Where(p => fileIds.Contains(p.FileId)).ToList();
        }

        public ConvertJob GetJob(Guid jobId)
        {
            return this.context.ConvertJobs.Where(p => p.ConvertJobId == jobId).SingleOrDefault();
        }

        public IEnumerable<ConvertJob> GetJobsBySession(Guid sessionId, bool includeFiles = false)
        {
            IQueryable<ConvertJob> q = this.context.ConvertJobs;

            if (includeFiles)
            {
                q = q.Include(c => c.InputFile).Include(c => c.OutputFile);
            }

            return q.Where(p => p.SessionId == sessionId).ToList();
        }

        public void UpdateJob(Guid jobId, byte? rating)
        {
            ConvertJob job = this.context.ConvertJobs.Where(p => p.ConvertJobId == jobId).Single();

            job.Rating = rating;

            this.context.ConvertJobs.Update(job);

            /*ConvertJob job = new ConvertJob
            {
                ConvertJobId = jobId
            };

            this.context.ConvertJobs.Attach(job);

            job.Rating = rating;*/

            this.context.SaveChanges();
        }
    }
}
