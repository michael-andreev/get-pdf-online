using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Api.Soap.Host
{
    public class RootPageHost
    {
        private string pageTemplate = @"<html>
    <head>
        <title>GetPDF.online SOAP API</title>
    </head>
    <body>
        <h1>GetPDF.online SOAP API</h1>
        <h2>Available services:</h2>
        <ul>
            <li>
                <h3>Converter V1 Service</h3>
                Endpoint: <a href=""{0}/Converter/V1/Service.svc"">{0}/Converter/V1/Service.svc</a>
                <br/>
                WSDL: <a href=""{0}/Converter/V1/Service.svc?wsdl"">{0}/Converter/V1/Service.svc?wsdl</a>
                <br/>
                Single WSDL: <a href=""{0}/Converter/V1/Service.svc?singleWsdl"">{0}/Converter/V1/Service.svc?singleWsdl</a>
            </li>
            <li>
                <h3>Statistics V1 Service</h3>
                Endpoint: <a href=""{0}/Statistics/V1/Service.svc"">{0}/Statistics/V1/Service.svc</a>
                <br/>
                WSDL: <a href=""{0}/Statistics/V1/Service.svc?wsdl"">{0}/Statistics/V1/Service.svc?wsdl</a>
                <br/>
                Single WSDL: <a href=""{0}/Statistics/V1/Service.svc?singleWsdl"">{0}/Statistics/V1/Service.svc?singleWsdl</a>
            </li>
        </ul>
    </body>
</html>";

        private string error404Template = @"<HTML>
<BODY>
<H1>Page not found (HTTP ERROR 404)</H1>
</BODY>
</HTML>";

        private HttpListener listener = new HttpListener();

        protected int portNumber;
        protected string uriPath;

        public RootPageHost(int portNumber, string uriPath)
        {
            this.portNumber = portNumber;
            this.uriPath = uriPath;
        }

        protected string GetAddress()
        {
            return $"http://+:{portNumber}{uriPath}/";
        }

        private void Listening()
        {
            try
            {
                while (listener.IsListening)
                {
                    // Note: The GetContext method blocks while waiting for a request. 
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;

                    // Obtain a response object.
                    HttpListenerResponse response = context.Response;

                    response.ContentType = "text/html; charset=UTF-8";
                    byte[] buffer;

                    if ((request.RawUrl == $"{uriPath}") || (request.RawUrl == $"{uriPath}/"))
                    {
                        // Construct a response.
                        buffer = System.Text.Encoding.UTF8.GetBytes(string.Format(this.pageTemplate, request.Url.ToString().TrimEnd('/')));
                    }
                    else
                    {
                        buffer = System.Text.Encoding.UTF8.GetBytes(this.error404Template);
                        response.StatusCode = 404;
                    }

                    // Get a response stream and write the response to it.
                    response.ContentLength64 = buffer.Length;
                    System.IO.Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    // You must close the output stream.
                    output.Close();
                }
            }
            catch (HttpListenerException)
            {
                //Listener was stopped
            }
        }

        public void Open()
        {
            if (!HttpListener.IsSupported)
                throw new NotSupportedException("Http listener in this OS is not supported.");

            listener.Prefixes.Add(this.GetAddress());

            listener.Start();

            Task listenTask = new Task(() => { this.Listening(); });
            listenTask.Start();
        }

        public void Close()
        {
            listener.Stop();
        }

        public bool IsOpened
        {
            get
            {
                return this.listener.IsListening;
            }
        }
    }
}
