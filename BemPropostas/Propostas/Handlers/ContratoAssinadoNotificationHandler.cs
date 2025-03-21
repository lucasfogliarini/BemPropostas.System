using BemPropostas.Propostas.Repository;
using CSharpFunctionalExtensions;
using MediatR;

namespace BemPropostas.Handlers;

public class ContratoAssinadoNotificationHandler(IPropostaRepository propostaRepository) : INotificationHandler<ContratoAssinadoNotification>
{
    public async Task Handle(ContratoAssinadoNotification notification, CancellationToken cancellationToken)
    {
        Result<Proposta> result = await propostaRepository.FindAsync(notification.PropostaId);
        result
            .EnsureNotNull("Proposta não encontrada.")
            .Tap(p =>
            {
                p.ContratoAssinado();
                propostaRepository.Database.Update(p);
                propostaRepository.Database.Commit();
            });
    }
}

public record ContratoAssinadoNotification(int PropostaId) : INotification;
