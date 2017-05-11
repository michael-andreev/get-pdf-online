using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using PrecizeSoft.GetPdfOnline.Api.Soap.Implementation.Converter.V1;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Api.Soap.Host.Converter.V1;
using PrecizeSoft.GetPdfOnline.Api.Soap.Host.Statistics.V1;

namespace PrecizeSoft.GetPdfOnline.Api.Soap.Host
{
    public class SoapApiHost
    {
        private RootPageHost rootPageHost = null;
        private ServiceHost converterV1ServiceHost = null;
        private ServiceHost conversionStatisticsV1ServiceHost = null;

        protected bool includeRootPage;
        protected int port;
        protected string uriPath;
        protected bool useLibreOfficeCustomPath;
        protected string libreOfficeCustomPath;
        protected string connectionString;

        protected bool isOpened = false;
        public bool IsOpened
        {
            get
            {
                return this.isOpened;
            }
        }

        public void Configure(bool includeRootPage, int port, string uriPath, bool useLibreOfficeCustomPath, string libreOfficeCustomPath,
            string connectionString)
        {
            this.includeRootPage = includeRootPage;
            this.port = port;
            this.uriPath = uriPath;
            this.useLibreOfficeCustomPath = useLibreOfficeCustomPath;
            this.libreOfficeCustomPath = libreOfficeCustomPath;
            this.connectionString = connectionString;
        }

        public void Open()
        {
            if (this.isOpened)
                throw new Exception("Soap API Host already opened.");

            if (this.includeRootPage)
            {
                this.rootPageHost = new RootPageHost(port, uriPath);
                this.rootPageHost.Open();
            }

            converterV1ServiceHost = new ConverterV1ServiceHost(port, uriPath, useLibreOfficeCustomPath, libreOfficeCustomPath, connectionString);
            converterV1ServiceHost.Open();

            conversionStatisticsV1ServiceHost = new StatisticsV1ServiceHost(port, uriPath, connectionString);
            conversionStatisticsV1ServiceHost.Open();

            this.isOpened = true;
        }

        public void Close()
        {
            if ((this.rootPageHost != null) && (this.rootPageHost.IsOpened))
            {
                this.rootPageHost.Close();
            }

            if ((this.converterV1ServiceHost != null) && (this.converterV1ServiceHost.State != CommunicationState.Closed))
            {
                this.converterV1ServiceHost.Close();
            }

            if ((this.conversionStatisticsV1ServiceHost != null) && (this.conversionStatisticsV1ServiceHost.State != CommunicationState.Closed))
            {
                this.conversionStatisticsV1ServiceHost.Close();
            }

            this.isOpened = false;
        }
    }
}
