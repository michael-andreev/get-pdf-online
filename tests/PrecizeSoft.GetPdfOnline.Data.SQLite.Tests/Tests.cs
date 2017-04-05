using System;
using Xunit;
using PrecizeSoft.GetPdfOnline.Data.SQLite;
using Microsoft.EntityFrameworkCore;
using System.IO;
using PrecizeSoft.GetPdfOnline.Data.SQLite.Repositories;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Tests
{
    public class Tests
    {
        [Fact]
        public void DatabaseCreateTest()
        {
            File.Delete("test.db");

            GetPdfOnlineDbContext context = new GetPdfOnlineDbContext("test.db");

            //context.Database.EnsureCreated();
            context.Database.Migrate();
            context.Seed();
            context.SaveChanges();

            Assert.NotNull(context);

            ConvertLogRepository repository = new ConvertLogRepository(context);

            var log = repository.GetConvertLog(new Guid("CFF29BD8-C0AB-4AC0-B932-06680205E7D2"));

            Assert.Equal(log.FileCategoryCode, "Document");
        }
    }
}
