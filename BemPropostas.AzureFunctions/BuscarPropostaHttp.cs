using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MediatR;
using BemPropostas.Handlers;

namespace BemPropostas.AzureFunctions
{
    public class BuscarPropostaHttp(IMediator mediator)
    {
        [FunctionName(nameof(BuscarPropostaHttp))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "propostas/{id}")] BuscarPropostaRequest buscarPropostaRequest,
            ILogger log)
        {
            var proposta = await mediator.Send(buscarPropostaRequest);

            return new OkObjectResult(proposta);
        }
    }
}
