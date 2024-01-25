using System.Net;
using EnergiaClienteDados.RequestModels;
using EnergiaClienteDados;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EnergiaCliente
{
    public class GetReadings
    {
        private readonly ILogger _logger;

        public GetReadings(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<GetReadings>();
        }

        [Function("GetReadings")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            Database database = new Database();

            var requestModel = new GetReadingsRequestModel() { habitation = int.Parse(req.Query.Get("habitation")), quantity = int.Parse(req.Query.Get("quantity")) };

            var data = database.GetReadings(requestModel);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            var jsonToReturn = JsonConvert.SerializeObject(data);

            response.WriteString(jsonToReturn);

            return response;
        }
    }
}
