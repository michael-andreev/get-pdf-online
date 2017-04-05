using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.IO.Services.Clients.ConversionStatistics.V1;
using PrecizeSoft.IO.Services.MessageContracts.ConversionStatistics.V1;

namespace PrecizeSoft.GetPdfOnline.Domain.Handlers
{
    public class GetStatByFileCategoriesViaService
    {
        protected ConversionStatisticsV1ServiceOptions serviceOptions;

        public GetStatByFileCategoriesViaService(ConversionStatisticsV1ServiceOptions serviceOptions)
        {
            this.serviceOptions = serviceOptions;
        }

        public IEnumerable<StatByFileCategory> Execute()
        {
            ServiceClient client = new ServiceClient(new EndpointAddress(this.serviceOptions.Address));

            List<StatByFileCategory> result =
                (from P in client.GetStatByFileCategories(new GetStatByFileCategoriesMessage()).Data
                 orderby P.TotalCount descending, P.FileCategoryCode ascending
                 select new StatByFileCategory
                 {
                     FileCategoryCode = P.FileCategoryCode,
                     TotalCount = P.TotalCount,
                     FileSizeAvg = P.FileSizeAvg,
                     FileSizeMax = P.FileSizeMax,
                     FileSizeMin = P.FileSizeMin,
                     FileSizeSum = P.FileSizeSum
                 }).ToList();

            return result;
        }
    }
}
