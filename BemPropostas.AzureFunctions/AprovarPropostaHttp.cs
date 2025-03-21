using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MediatR;
using BemPropostas.Handlers;

namespace BemPropostas.AzureFunctions
{
    public class AprovarPropostaHttp(IMediator mediator)
    {
        [FunctionName(nameof(AprovarPropostaHttp))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "propostas/aprovar")] AprovarPropostaRequest request,
            ILogger log)
        {
            var response = await mediator.Send(request);

            return new OkObjectResult(response);
        }
    }
}
