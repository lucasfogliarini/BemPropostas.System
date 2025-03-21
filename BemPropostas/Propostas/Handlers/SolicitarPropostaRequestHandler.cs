using BemPropostas.Propostas.Repository;
using MediatR;

namespace BemPropostas.Handlers;

public class SolicitarPropostaRequestHandler(IPropostaRepository propostaRepository) : IRequestHandler<SolicitarPropostaRequest, SolicitarPropostaResponse>
{
    public async Task<SolicitarPropostaResponse> Handle(SolicitarPropostaRequest request, CancellationToken cancellationToken)
    {
        var proposta = new Proposta(request.ClienteId, request.ValorSolicitado, request.Prazo);
        propostaRepository.Database.Add(proposta);
        await propostaRepository.Database.CommitAsync();
        return new SolicitarPropostaResponse(proposta.Id, proposta.Numero, proposta.Status, proposta.DataCriacao);
    }
}

public record SolicitarPropostaRequest(int ClienteId, decimal ValorSolicitado, int Prazo) : IRequest<SolicitarPropostaResponse>;

public record SolicitarPropostaResponse(int Id, string Numero, StatusProposta Status, DateTime DataCriacao);
