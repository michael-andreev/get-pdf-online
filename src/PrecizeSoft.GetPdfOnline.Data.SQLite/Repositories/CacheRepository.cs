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

        public void CreateResultFile(ResultFile resultFile)
        {
            this.context.ResultFiles.Add(resultFile);
            this.context.SaveChanges();
        }

        public void DeleteResultFile(Guid resultFileId)
        {
            throw new NotImplementedException();
        }

        public ResultFile GetResultFile(Guid resultFileId, bool includeContent = false)
        {
            IQueryable<ResultFile> q = this.context.ResultFiles;

            if (includeContent)
            {
                q = q.Include("Content");
            }

            return q.Where(p => p.ResultFileId == resultFileId).SingleOrDefault();
        }

        public IEnumerable<ResultFile> GetResultFilesBySessionId(string sessionId)
        {
            return this.context.ResultFiles.Where(p => p.SessionId == sessionId).ToList();
        }
    }
}
