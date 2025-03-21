using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MediatR;
using BemPropostas.Handlers;

namespace BemPropostas.AzureFunctions
{
    public class SolicitarPropostaHttp(IMediator mediator)
    {
        [FunctionName(nameof(SolicitarPropostaHttp))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "propostas")] SolicitarPropostaRequest request,
            ILogger log)
        {
            var proposta = await mediator.Send(request);

            return new OkObjectResult(proposta);
        }
    }
}
