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

        private static object CreateSessionLocker = new object();

        public void CreateJob(ConvertJob job, bool createSessionIfNotExists)
        {
            if (createSessionIfNotExists && (job.SessionId.HasValue)
                && (!this.context.ConvertSessions.Where(p => p.SessionId == job.SessionId).Any()))
            {
                lock (CreateSessionLocker)
                {
                    if (!this.context.ConvertSessions.Where(p => p.SessionId == job.SessionId).Any())
                    {
                        this.context.ConvertSessions.Add(new ConvertSession
                        {
                            SessionId = job.SessionId.Value,
                            CreateDateUtc = DateTime.UtcNow
                        });

                        this.context.SaveChanges();
                    }
                }
            }

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

        public void DeleteFiles(IEnumerable<Guid> fileIds)
        {
            IEnumerable<BinaryFile> filesToDelete = this.context.BinaryFiles.Where(p => fileIds.Contains(p.FileId)).ToList();

            this.context.BinaryFiles.RemoveRange(filesToDelete);

            this.context.SaveChanges();
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

        public void DeleteSession(Guid sessionId)
        {
            ConvertSession session = this.context.ConvertSessions.Where(p => p.SessionId == sessionId).Single();

            this.context.ConvertSessions.Remove(session);

            this.context.SaveChanges();
        }

        public bool SessionExists(Guid sessionId)
        {
            return this.context.ConvertSessions.Where(p => p.SessionId == sessionId).Any();
        }

        public void DeleteExpiredData()
        {
            // EF can't translate DateTime.Now to DB and executes it locally.
            // To prevent EF warnings we use variable for date comparison instead of DateTime.UtcNow value in queries
            DateTime currentDate = DateTime.UtcNow;

            // EF can't translate Union to DB and executes it locally. To prevent warnings, we manually
            // execute Union locally (call ToList method in subqueries)
            List<Guid> expiredFileIds =
                (
                (from P in this.context.ConvertJobs
                 where P.ExpireDateUtc < currentDate
                 select P.InputFileId).ToList()
                .Union((from P in this.context.ConvertJobs
                 where P.ExpireDateUtc < currentDate && P.OutputFileId.HasValue
                 select P.OutputFileId.Value).ToList())
                 ).ToList();

            this.context.BinaryFiles.RemoveRange(
                from P in this.context.BinaryFiles
                where expiredFileIds.Contains(P.FileId)
                select P);

            this.context.ConvertJobs.RemoveRange(
                from P in this.context.ConvertJobs
                where P.ExpireDateUtc < currentDate
                select P);

            this.context.SaveChanges();
        }
    }
}
