using PrecizeSoft.GetPdfOnline.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite
{
    public partial class CacheDbContext : ISeedDatabase
    {
        public void Seed()
        {
            this.SeedForSession(null);
        }

        public void SeedForSession(string sessionId)
        {
            if (this.ResultFiles.Count() > 0) return;

            this.ResultFiles.Add(new ResultFile
            {
                ResultFileId = Guid.NewGuid(),
                FileName = "Text document 1.pdf",
                FileSize = 48622,
                SessionId = sessionId,
                CreateDateUtc = DateTime.Now.ToUniversalTime(),
                ExpireDateUtc = DateTime.Now.ToUniversalTime(),
                Content = new ResultFileContent
                {
                    FileBytes = new byte[3] { 0, 1, 2 }
                }
            });

            this.ResultFiles.Add(new ResultFile
            {
                ResultFileId = Guid.NewGuid(),
                FileName = "Spreadsheet 1.pdf",
                FileSize = 232365,
                SessionId = sessionId,
                CreateDateUtc = DateTime.Now.ToUniversalTime(),
                ExpireDateUtc = DateTime.Now.ToUniversalTime(),
                Content = new ResultFileContent
                {
                    FileBytes = new byte[3] { 0, 1, 2 }
                }
            });

            this.ResultFiles.Add(new ResultFile
            {
                ResultFileId = Guid.NewGuid(),
                FileName = "Photography.pdf",
                FileSize = 3867042,
                SessionId = sessionId,
                CreateDateUtc = DateTime.Now.ToUniversalTime(),
                ExpireDateUtc = DateTime.Now.ToUniversalTime(),
                Content = new ResultFileContent
                {
                    FileBytes = new byte[3] { 0, 1, 2 }
                }
            });

            this.SaveChanges();
        }
    }
}
