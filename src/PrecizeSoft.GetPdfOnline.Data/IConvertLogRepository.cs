using System;
using System.Collections.Generic;
using PrecizeSoft.GetPdfOnline.Model;

namespace PrecizeSoft.GetPdfOnline.Data
{
    public interface IConvertLogRepository
    {
        void CreateRequest(ConvertRequest convertRequest);

        void CreateResponse(ConvertResponse convertResponse);

        IEnumerable<FileCategory> GetFileCategories();

        IEnumerable<FileType> GetFileTypes();
    }
}
