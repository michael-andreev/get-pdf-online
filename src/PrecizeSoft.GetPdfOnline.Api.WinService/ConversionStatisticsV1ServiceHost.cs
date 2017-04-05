using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Api.Implementation.ConversionStatistics.V1;
using PrecizeSoft.GetPdfOnline.Data;

namespace PrecizeSoft.GetPdfOnline.Api.WinService
{
    public class ConversionStatisticsV1ServiceHost: ServiceHost
    {
        public ConversionStatisticsV1ServiceHost(int port, string connectionString):
            base(typeof(Service), new Uri($"http://localhost:{port}/ConversionStatistics/V1/Service.svc"))
        {
            V1ServiceConfiguration.ConnectionString = connectionString;
        }
    }
}
