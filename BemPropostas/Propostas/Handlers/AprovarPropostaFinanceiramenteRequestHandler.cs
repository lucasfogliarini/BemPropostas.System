using BemPropostas.Propostas.Repository;
using CSharpFunctionalExtensions;
using MediatR;

namespace BemPropostas.Handlers;

public class AprovarPropostaFinanceiramenteRequestHandler(IPropostaRepository propostaRepository) : IRequestHandler<AprovarPropostaFinanceiramenteRequest, Result<AprovarPropostaFinanceiramenteResponse>>
{
    public async Task<Result<AprovarPropostaFinanceiramenteResponse>> Handle(AprovarPropostaFinanceiramenteRequest request, CancellationToken cancellationToken)
    {
        Result<Proposta> result = await propostaRepository.FindAsync(request.Id);
        return result
            .EnsureNotNull("Proposta não encontrada.")
            .Tap(p=>
            {
                p.AprovarFinanceiramente(request.TaxaJuros, request.ValorParcela);
                propostaRepository.Database.Update(p);
                propostaRepository.Database.Commit();
            })
            .MapTry(p => new AprovarPropostaFinanceiramenteResponse(p.Id, p.Numero, p.Status, p.TaxaJuros,p.ValorParcela));
    }
}

public record AprovarPropostaFinanceiramenteRequest(int Id, decimal TaxaJuros, decimal ValorParcela) : IRequest<Result<AprovarPropostaFinanceiramenteResponse>>;

public record AprovarPropostaFinanceiramenteResponse(int Id, string Numero, StatusProposta Status, decimal TaxaJuros, decimal ValorParcela);
