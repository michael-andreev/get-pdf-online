using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Api.Implementation.Converter.V1;

namespace PrecizeSoft.GetPdfOnline.Api.WinService
{
    public class ConverterV1ServiceHost: ServiceHost
    {
        public ConverterV1ServiceHost(int port, bool useLibreOfficeCustomPath, string libreOfficeCustomPath):
            base(typeof(Service), new Uri($"http://localhost:{port}/Converter/V1/Service.svc"))
        {
            ServiceConverterConfiguration.LibreOfficePath = useLibreOfficeCustomPath ? libreOfficeCustomPath : null;
        }
    }
}
