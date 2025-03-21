using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MediatR;

namespace BemPropostas.AzureFunctions
{
    public class ContratoCriadoHttp(IMediator mediator)
    {
        [FunctionName(nameof(ContratoCriadoHttp))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "contrato-criado")] ContratoCriadoNotification notification,
            ILogger log)
        {
            await mediator.Send(notification);

            return new OkObjectResult(true);
        }
    }
}
