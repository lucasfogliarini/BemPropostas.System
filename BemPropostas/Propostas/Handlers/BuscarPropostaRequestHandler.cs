using BemPropostas.Propostas.Repository;
using CSharpFunctionalExtensions;
using MediatR;

namespace BemPropostas.Handlers;

public class BuscarPropostaRequestHandler(IPropostaRepository propostasRepository) : IRequestHandler<BuscarPropostaRequest, Result<BuscarPropostaResponse>>
{
    public async Task<Result<BuscarPropostaResponse>> Handle(BuscarPropostaRequest request, CancellationToken cancellationToken)
    {
        Result<Proposta> result = await propostasRepository.FindAsync(request.Id);
        return result
            .EnsureNotNull("Proposta não encontrada.")
            .MapTry(p=> new BuscarPropostaResponse(p.Id, p.Numero, p.Status, p.DataCriacao));
    }
}

public record BuscarPropostaRequest(int Id) : IRequest<Result<BuscarPropostaResponse>>;

public record BuscarPropostaResponse(int Id, string Numero, StatusProposta Status, DateTime DataCriacao);
