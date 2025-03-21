using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MediatR;
using BemPropostas.Handlers;

namespace BemPropostas.AzureFunctions
{
    public class CriarPropostaHttp(IMediator mediator)
    {
        [FunctionName(nameof(CriarPropostaHttp))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "propostas")] CriarPropostaRequest criarPropostaRequest,
            ILogger log)
        {
            var proposta = await mediator.Send(criarPropostaRequest);

            return new OkObjectResult(proposta);
        }
    }
}
