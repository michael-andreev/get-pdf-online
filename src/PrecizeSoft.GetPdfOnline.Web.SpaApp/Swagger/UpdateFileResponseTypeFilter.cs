using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using System.Net;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp.Swagger
{
    internal class UpdateFileResponseTypeFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            /*if (context.ApiDescription.GetControllerAndActionAttributes<SwaggerResponseRemoveDefaultsAttribute>().Any())
                operation.responses.Clear();*/

            var responseAttributes =
                from P in context.ApiDescription.ActionAttributes()
                where P is SwaggerFileResponseAttribute
                orderby ((SwaggerFileResponseAttribute)P).StatusCode
                select (SwaggerFileResponseAttribute)P;

            if (responseAttributes.Any())
            {
                foreach (var attr in responseAttributes)
                {
                    var statusCode = attr.StatusCode.ToString();

                    Schema responseSchema = new Schema { Type = "file" };

                    operation.Responses[statusCode] = new Response
                    {
                        Description = attr.Description ?? InferDescriptionFrom(statusCode),
                        Schema = responseSchema
                    };
                }

                operation.Produces.Add("application/octet-stream");
            }
        }

        private string InferDescriptionFrom(string statusCode)
        {
            HttpStatusCode enumValue;
            if (Enum.TryParse(statusCode, true, out enumValue))
            {
                return enumValue.ToString();
            }
            return null;
        }
    }
}
