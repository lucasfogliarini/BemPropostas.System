using BemPropostas.Propostas.Repository;
using CSharpFunctionalExtensions;
using MediatR;

namespace BemPropostas.Handlers;

public class AprovarPropostaRequestHandler(IPropostaRepository propostaRepository) : IRequestHandler<AprovarPropostaRequest, Result<AprovarPropostaResponse>>
{
    public async Task<Result<AprovarPropostaResponse>> Handle(AprovarPropostaRequest request, CancellationToken cancellationToken)
    {
        Result<Proposta> result = await propostaRepository.FindAsync(request.Id);
        return result
            .EnsureNotNull("Proposta não encontrada.")
            .Tap(p =>
            {
                p.Aprovar();
                propostaRepository.Database.Update(p);
                propostaRepository.Database.Commit();
            })
            .MapTry(p => new AprovarPropostaResponse(p.Id, p.Numero, p.Status, p.DataAprovacao.Value));
    }
}

public record AprovarPropostaRequest(int Id) : IRequest<Result<AprovarPropostaResponse>>;

public record AprovarPropostaResponse(int Id, string Numero, StatusProposta Status, DateTime DataAprovacao);
