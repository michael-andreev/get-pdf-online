using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Api.WinService
{
    public class RootPageHost
    {
        private string pageTemplate = @"<HTML>
<BODY>
<H1>GetPDF.online API</H1>
<H2>Available services:</H2>
<UL>
<LI>Converter V1 Service (SOAP) - <a href=""{0}Converter/V1/Service.svc"">{0}Converter/V1/Service.svc</a></LI>
<LI>Conversion Statistics V1 Service (SOAP) - <a href=""{0}ConversionStatistics/V1/Service.svc"">{0}ConversionStatistics/V1/Service.svc</a></LI>
</UL>
</BODY>
</HTML>";

        private string error404Template = @"<HTML>
<BODY>
<H1>Page not found (HTTP ERROR 404)</H1>
</BODY>
</HTML>";

        private HttpListener listener = new HttpListener();

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

                    if (request.RawUrl == "/")
                    {
                        // Construct a response.
                        buffer = System.Text.Encoding.UTF8.GetBytes(string.Format(this.pageTemplate, request.Url));
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

        public void Open(int portNumber)
        {
            if (!HttpListener.IsSupported)
                throw new NotSupportedException("Http listener in this OS is not supported.");

            listener.Prefixes.Add($"http://+:{portNumber}/");

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
