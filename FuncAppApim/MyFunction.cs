using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace FuncAppApim
{
    public static class MyFunction
    {
        [FunctionName("MyFunction")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "myfunction" })]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "The OK response")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            string name = req.Query["name"];

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject($"Hello, {name}"))
            };
        }
    }
}
