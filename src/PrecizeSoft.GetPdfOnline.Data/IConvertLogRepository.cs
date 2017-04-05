using System;
using System.Collections.Generic;
using PrecizeSoft.GetPdfOnline.Model;

namespace PrecizeSoft.GetPdfOnline.Data
{
    public interface IConvertLogRepository
    {
        void CreateConvertRequest(ConvertRequest convertRequest);

        void CreateConvertResponse(ConvertResponse convertResponse);

        IEnumerable<FileCategory> GetFileCategories();

        IEnumerable<FileType> GetFileTypes();

        FileType GetFileTypeByExtension(string fileExtension);

        ConvertLog GetConvertLog(Guid convertRequestId);

        ConvertStatTotal GetConvertStatTotal();

        IEnumerable<ConvertStatByFileCategory> GetConvertStatByFileCategories();

        IEnumerable<ConvertStatByHour> GetConvertStatByHoursForDay(DateTimeOffset dateWithTimeZone);
    }
}
