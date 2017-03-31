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

        public void CreateRequest(ConvertRequest convertRequest)
        {
            throw new NotImplementedException();
        }

        public void CreateResponse(ConvertResponse convertResponse)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileCategory> GetFileCategories()
        {
            return this.context.FileCategories.ToList();
        }

        public IEnumerable<FileType> GetFileTypes()
        {
            return this.context.FileTypes.ToList();
        }
    }
}
