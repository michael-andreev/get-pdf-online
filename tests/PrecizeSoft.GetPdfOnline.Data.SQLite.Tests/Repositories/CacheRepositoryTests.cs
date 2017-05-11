using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PrecizeSoft.GetPdfOnline.Data.SQLite.Repositories;
using PrecizeSoft.GetPdfOnline.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Tests.Repositories
{
    public class CacheRepositoryTests
    {

        [Fact]
        public void CreateResultFileTest()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=cache.db");
            connection.Open();

            DbContextOptionsBuilder<CacheDbContext> optionsBuilder = new DbContextOptionsBuilder<CacheDbContext>()
                .UseSqlite(connection);

            CacheDbContext context = new CacheDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            CacheRepository repository = new CacheRepository(context);

            Guid resultFileId = Guid.NewGuid();

            byte[] fileBytes = new byte[1];
            fileBytes[0] = 1;

            BinaryFile resultFile = new BinaryFile
            {
                FileId = resultFileId,
                CreateDateUtc = DateTime.Now,
                FileName = "test.pdf",
                FileSize = fileBytes.Length,
                Content = new BinaryFileContent
                {
                    FileBytes = fileBytes
                }
            };

            repository.CreateFile(resultFile);

            Assert.NotNull(repository.GetFile(resultFileId));
        }
    }
}
