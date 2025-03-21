using BemPropostas.Propostas.Repository;
using MediatR;

namespace BemPropostas.Handlers;

public class CriarPropostaRequestHandler(IPropostasRepository propostasRepository) : IRequestHandler<CriarPropostaRequest, CriarPropostaResponse>
{
    public async Task<CriarPropostaResponse> Handle(CriarPropostaRequest request, CancellationToken cancellationToken)
    {
        var proposta = new Proposta(request.ClienteId, request.ValorSolicitado, request.Prazo);
        propostasRepository.Add(proposta);
        await propostasRepository.Database.CommitAsync();
        return new CriarPropostaResponse(proposta.Id, proposta.Numero, proposta.Status, proposta.DataCriacao);
    }
}

public record CriarPropostaRequest(int ClienteId, decimal ValorSolicitado, int Prazo) : IRequest<CriarPropostaResponse>;

public record CriarPropostaResponse(int Id, string Numero, StatusProposta Status, DateTime DataCriacao);
