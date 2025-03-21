using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using MediatR;
using BemPropostas.Handlers;

namespace BemPropostas.AzureFunctions
{
    //simulando um consumer capturando um evento de domínio
    public class ContratoAssinadoHttp(IMediator mediator)
    {
        [FunctionName(nameof(ContratoAssinadoHttp))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "contrato-assinado")] ContratoAssinadoNotification notification,
            ILogger log)
        {
            await mediator.Publish(notification);

            return new OkObjectResult(true);
        }
    }
}
