using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MediatR;
using BemPropostas.Handlers;

namespace BemPropostas.AzureFunctions
{
    public class AprovarPropostaFinanceiramenteHttp(IMediator mediator)
    {
        [FunctionName(nameof(AprovarPropostaFinanceiramenteHttp))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "propostas/{id}/aprovarfinanceiramente")] AprovarPropostaFinanceiramenteRequest request,
            ILogger log)
        {
            var response = await mediator.Send(request);

            return new OkObjectResult(response);
        }
    }
}
