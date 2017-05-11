using PrecizeSoft.GetPdfOnline.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Data.SQLite.Repositories;
using PrecizeSoft.GetPdfOnline.Data.SQLite;

namespace PrecizeSoft.GetPdfOnline.Api.Soap.Implementation.Converter.V1
{
    public class LoggerServiceWrapper : LoggerService
    {
        public LoggerServiceWrapper() : base(CreateRepository())
        {
        }

        protected static IConvertLogRepository CreateRepository()
        {
            return new ConvertLogRepository(new GetPdfOnlineDbContext(V1ServiceConfiguration.ConnectionString));
        }
    }
}
