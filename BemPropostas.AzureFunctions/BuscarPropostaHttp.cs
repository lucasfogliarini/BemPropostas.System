using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MediatR;
using Microsoft.AspNetCore.Http;
using BemPropostas.Handlers;

namespace BemPropostas.AzureFunctions
{
    public class BuscarPropostaHttp(IMediator mediator)
    {
        [FunctionName(nameof(BuscarPropostaHttp))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "propostas/{id}")] HttpRequest request,
            ILogger log)
        {
            if(request.RouteValues.TryGetValue("id", out object id))
            {
                var _id = int.Parse(id.ToString());
                var proposta = await mediator.Send(new BuscarPropostaRequest(_id));
                return new OkObjectResult(proposta);
            }

            return new BadRequestResult();
        }
    }
}
