using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PrecizeSoft.GetPdfOnline.Data.SQLite.Repositories;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Tests
{
    public class SeedFixture : IDisposable
    {
        protected GetPdfOnlineDbContext context;

        public IConvertLogRepository repository { get; private set; }

        public SeedFixture()
        {
            this.context = new GetPdfOnlineDbContext("Data Source=UnitTests.db");

            context.Database.Migrate();
            context.Seed();
            context.SaveChanges();

            this.repository = new ConvertLogRepository(context);
        }

        public void Dispose()
        {
            //File.Delete("UnitTests.db");
        }
    }
}
