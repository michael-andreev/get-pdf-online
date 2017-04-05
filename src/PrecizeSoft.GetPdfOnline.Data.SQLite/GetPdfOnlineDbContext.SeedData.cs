using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using PrecizeSoft.GetPdfOnline.Model;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite
{
    public partial class GetPdfOnlineDbContext : ISeedDatabase
    {
        public void Seed()
        {
            this.SeedTestData();
        }

        public void SeedTestData()
        {
            #region Completed query
            {
                Guid requestId = new Guid("CFF29BD8-C0AB-4AC0-B932-06680205E7D2");

                if (!this.ConvertRequests.Where(p => p.ConvertRequestId == requestId).Any())
                {
                    ConvertRequest request = new ConvertRequest()
                    {
                        ConvertRequestId = requestId,
                        RequestDateUtc = DateTime.Now.ToUniversalTime(),
                        FileExtension = ".docx",
                        FileSize = 10,
                        SenderIp = "127.0.0.1",
                        FileType = this.FileTypes.Where(p => p.FileExtension == ".docx").SingleOrDefault()
                    };

                    this.ConvertRequests.Add(request);

                    ConvertResponse response = new ConvertResponse()
                    {
                        ConvertResponseId = requestId,
                        ResponseDateUtc = DateTime.Now.ToUniversalTime(),
                        ResultFileSize = 20,
                        ResultTypeId = 1
                    };

                    this.ConvertResponses.Add(response);
                }
            }
            #endregion

            #region Uncompleted query
            {
                Guid requestId = new Guid("78CBECAC-32B9-451A-9D40-7353885A8B4B");

                if (!this.ConvertRequests.Where(p => p.ConvertRequestId == requestId).Any())
                {
                    ConvertRequest request = new ConvertRequest()
                    {
                        ConvertRequestId = requestId,
                        RequestDateUtc = DateTime.Now.ToUniversalTime(),
                        FileExtension = ".xlsx",
                        FileSize = 30,
                        SenderIp = "127.0.0.1",
                        FileType = this.FileTypes.Where(p => p.FileExtension == ".xlsx").SingleOrDefault()
                    };

                    this.ConvertRequests.Add(request);
                }
            }
            #endregion

            #region Error query
            {
                Guid requestId = new Guid("7EA30F36-E5E1-4A73-90FA-853A62CBA6C6");

                if (!this.ConvertRequests.Where(p => p.ConvertRequestId == requestId).Any())
                {
                    ConvertRequest request = new ConvertRequest()
                    {
                        ConvertRequestId = requestId,
                        RequestDateUtc = DateTime.Now.ToUniversalTime(),
                        FileExtension = ".ppt",
                        FileSize = 25,
                        SenderIp = "127.0.0.1",
                        FileType = this.FileTypes.Where(p => p.FileExtension == ".ppt").SingleOrDefault()
                    };

                    this.ConvertRequests.Add(request);

                    ConvertResponse response = new ConvertResponse()
                    {
                        ConvertResponseId = requestId,
                        ResponseDateUtc = DateTime.Now.ToUniversalTime(),
                        ResultTypeId = 10
                    };

                    this.ConvertResponses.Add(response);
                }
            }
            #endregion
        }
    }
}
