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
            this.SeedForSession(Guid.NewGuid());
        }

        public void SeedForSession(Guid sessionId)
        {
            if (this.BinaryFiles.Count() > 0) return;

            this.ConvertJobs.Add(new ConvertJob
            {
                ConvertJobId = sessionId,
                SessionId = sessionId,
                ExpireDateUtc = DateTime.UtcNow,
                Rating = null,
                InputFile = new BinaryFile
                {
                    FileId = Guid.NewGuid(),
                    FileName = "Text document 1.doc",
                    FileSize = 48622,
                    CreateDateUtc = DateTime.Now.ToUniversalTime(),
                    Content = new BinaryFileContent
                    {
                        FileBytes = new byte[3] { 0, 1, 2 }
                    }
                },
                OutputFile = new BinaryFile
                {
                    FileId = Guid.NewGuid(),
                    FileName = "Text document 1.pdf",
                    FileSize = 482462,
                    CreateDateUtc = DateTime.Now.ToUniversalTime(),
                    Content = new BinaryFileContent
                    {
                        FileBytes = new byte[3] { 0, 1, 2 }
                    }
                }
            });

            this.SaveChanges();
        }
    }
}
