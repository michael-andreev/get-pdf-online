using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Api.Implementation.Converter.V1;
using PrecizeSoft.GetPdfOnline.Data;

namespace PrecizeSoft.GetPdfOnline.Api.WinService
{
    public class ConverterV1ServiceHost: ServiceHost
    {
        public ConverterV1ServiceHost(int port, bool useLibreOfficeCustomPath, string libreOfficeCustomPath, string connectionString) :
            base(typeof(Service), new Uri($"http://localhost:{port}/Converter/V1/Service.svc"))
        {
            V1ServiceConfiguration.LibreOfficePath = useLibreOfficeCustomPath ? libreOfficeCustomPath : null;
            V1ServiceConfiguration.ConnectionString = connectionString;
        }
    }
}
