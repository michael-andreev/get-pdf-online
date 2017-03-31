using System;
using Xunit;
using PrecizeSoft.GetPdfOnline.Data.SQLite;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Tests
{
    public class Tests
    {
        [Fact]
        public void DatabaseCreateTest()
        {
            File.Delete("test.db");

            GetPdfOnlineDbContext context = new GetPdfOnlineDbContext("test.db");

            context.Database.EnsureCreated();
            //context.Database.Migrate();
            context.SeedDirectories();
            context.SaveChanges();

            Assert.NotNull(context);
        }
    }
}
