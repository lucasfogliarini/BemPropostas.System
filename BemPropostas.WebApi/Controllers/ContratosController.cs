using BemPropostas.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BemPropostas.WebApi.Controllers
{
    //simulando um consumer capturando um evento de domínio
    public class ContratosController(IMediator mediator) : Controller
    {
        [HttpPost("assinado")]
        public async Task Assinado(ContratoAssinadoNotification contratoAssinado)
        {
            await mediator.Publish(contratoAssinado);
        }
    }
}
