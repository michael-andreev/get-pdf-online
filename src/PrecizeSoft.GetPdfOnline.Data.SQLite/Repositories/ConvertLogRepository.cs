using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Model;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite.Repositories
{
    public class ConvertLogRepository : IConvertLogRepository
    {
        public GetPdfOnlineDbContext context;

        public ConvertLogRepository(GetPdfOnlineDbContext dbContext)
        {
            this.context = dbContext;
        }

        public void CreateConvertRequest(ConvertRequest convertRequest)
        {
            this.context.ConvertRequests.Add(convertRequest);
            this.context.SaveChanges();
        }

        public void CreateConvertResponse(ConvertResponse convertResponse)
        {
            this.context.ConvertResponses.Add(convertResponse);
            this.context.SaveChanges();
        }

        public ConvertLog GetConvertLog(Guid convertRequestId)
        {
            return this.context.ConvertLogs.Where(p => p.ConvertRequestId == convertRequestId).SingleOrDefault();
        }

        public IEnumerable<ConvertStatByFileCategory> GetConvertStatByFileCategories()
        {
            return this.context.ConvertStatByFileCategory.ToList();
        }

        public IEnumerable<ConvertStatByHour> GetConvertStatByHoursForDay(DateTimeOffset dateWithTimeZone)
        {
            if (dateWithTimeZone.Offset.Minutes % 15 != 0)
            {
                //Wrong time zone
                throw new ArgumentException("dateWithTimeZone");
            }

            DateTime beginDate = dateWithTimeZone.UtcDateTime;

            DateTime endDate = beginDate.AddHours(24);

            int utcMinutesOffset = dateWithTimeZone.Offset.Minutes;

            return this.context.ConvertStatByHour
                .Where(p => p.BeginRequestDateUtc >= beginDate
                && p.BeginRequestDateUtc < endDate
                && p.UtcMinutesOffset == utcMinutesOffset)
                .ToList();
        }

        public ConvertStatTotal GetConvertStatTotal()
        {
            return this.context.ConvertStatTotal.SingleOrDefault();
        }

        public IEnumerable<FileCategory> GetFileCategories()
        {
            return this.context.FileCategories.ToList();
        }

        public FileType GetFileTypeByExtension(string fileExtension)
        {
            return this.context.FileTypes.Where(p => p.FileExtension.ToLower() == fileExtension.ToLower()).SingleOrDefault();
        }

        public IEnumerable<FileType> GetFileTypes()
        {
            return this.context.FileTypes.ToList();
        }
    }
}
