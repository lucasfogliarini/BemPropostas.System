using BemPropostas.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BemPropostas.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PropostasController(IMediator mediator, ILogger<PropostasController> logger) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<BuscarPropostaResponse> Buscar(int id)
    {
        var response = await mediator.Send(new BuscarPropostaRequest(id));
        return response.Value;
    }

    [HttpPost]
    public async Task<SolicitarPropostaResponse> Solicitar(SolicitarPropostaRequest request)
    {
        var response = await mediator.Send(request);
        return response;
    }

    [HttpPost("aprovar")]
    public async Task<AprovarPropostaResponse> Aprovar(AprovarPropostaRequest request)
    {
        var response = await mediator.Send(request);
        return response.Value;
    }

    [HttpPost("aprovarfinanceiramente")]
    public async Task<AprovarPropostaFinanceiramenteResponse> AprovarFinanceiramente(AprovarPropostaFinanceiramenteRequest request)
    {
        var response = await mediator.Send(request);
        return response.Value;
    }
}
