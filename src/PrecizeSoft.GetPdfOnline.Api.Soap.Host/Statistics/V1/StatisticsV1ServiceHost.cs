using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Api.Soap.Implementation.Statistics.V1;
using PrecizeSoft.GetPdfOnline.Data;

namespace PrecizeSoft.GetPdfOnline.Api.Soap.Host.Statistics.V1
{
    public class StatisticsV1ServiceHost: ServiceHost
    {
        public StatisticsV1ServiceHost(int port, string uriPath, string connectionString):
            base(typeof(Service), new Uri($"http://localhost:{port}{uriPath}/Statistics/V1/Service.svc"))
        {
            V1ServiceConfiguration.ConnectionString = connectionString;
        }
    }
}
