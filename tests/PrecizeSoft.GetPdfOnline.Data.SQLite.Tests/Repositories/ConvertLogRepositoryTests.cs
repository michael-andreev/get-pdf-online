using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrecizeSoft.GetPdfOnline.Data.SQLite.Repositories;
using Xunit;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Tests.Repositories
{
    public class ConvertLogRepositoryTests: IClassFixture<SeedFixture>
    {
        private SeedFixture fixture;

        public ConvertLogRepositoryTests(SeedFixture fixture)
        {
            this.fixture = fixture;
        }

        /* public void CreateConvertRequestTest()
        {
        } */

        /* public void CreateConvertResponseTest()
        {
        } */

        [Fact]
        public void GetConvertLogTest()
        {
            Assert.NotNull(fixture.repository.GetConvertLog(new Guid("CFF29BD8-C0AB-4AC0-B932-06680205E7D2")));
        }

        [Fact]
        public void GetConvertStatByFileCategoryTest()
        {
            Assert.True(fixture.repository.GetConvertStatByFileCategories().Count() > 0);
        }

        [Fact]
        public void GetConvertStatByHoursForDay()
        {
            DateTimeOffset today = new DateTimeOffset(DateTime.Now.Date, TimeZoneInfo.Local.BaseUtcOffset);

            Assert.True(fixture.repository.GetConvertStatByHoursForDay(today).Count() == 1);
        }

        [Fact]
        public void GetConvertStatTotal()
        {
            Assert.NotNull(fixture.repository.GetConvertStatTotal());
        }

        /* public void GetFileCategories()
        {
        } */

        /* public void GetFileTypeByExtension()
        {
        } */

        /* public void GetFileTypes()
        {
        } */
    }
}
