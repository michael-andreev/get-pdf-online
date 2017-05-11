using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Data.SQLite;
using PrecizeSoft.GetPdfOnline.Data.SQLite.Repositories;
using PrecizeSoft.GetPdfOnline.Domain.Handlers;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.IO.Wcf.Implementation.Converter.V1;
using PrecizeSoft.IO.Contracts.Converters;

namespace PrecizeSoft.GetPdfOnline.Api.Soap.Implementation.Converter.V1
{
    public class Service : WcfConverterV1Service<ConverterServiceWrapper, LoggerServiceWrapper>
    {
    }
}
