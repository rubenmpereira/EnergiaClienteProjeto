using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using EnergiaClienteDados;
using EnergiaClienteDominio;
using EnergiaClienteDados.RequestModels;
using Grpc.Core;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace EnergiaCliente
{
    public class EnergiaClienteController
    {
        private readonly ILogger _logger;

        public EnergiaClienteController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<EnergiaClienteController>();
        }

        [Function("GetInvoices")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            Database database = new Database();

            var param = req.Query.Get("habitation");
            var data = database.GetInvoices(new GetInvoicesRequestModel() { habitation = int.Parse(param) });

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            var jsonToReturn = JsonConvert.SerializeObject(data);

            response.WriteString(jsonToReturn);

            return response;
        }
    }
}
