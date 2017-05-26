using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp.Swagger
{
    /// <summary>
    /// SwaggerFileResponseAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public sealed class SwaggerFileResponseAttribute : SwaggerResponseAttribute
    {
        public SwaggerFileResponseAttribute(HttpStatusCode statusCode) : base((int)statusCode)
        {
        }

        public SwaggerFileResponseAttribute(HttpStatusCode statusCode, Type type = null, string description = null)
            : base((int)statusCode, type, description)
        {
        }

        public SwaggerFileResponseAttribute(int statusCode) : base(statusCode)
        {
        }

        public SwaggerFileResponseAttribute(int statusCode, Type type = null, string description = null)
            : base(statusCode, type, description)
        {
        }
    }
}
