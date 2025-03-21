using MediatR;

namespace BemPropostas.Handlers;

public class ContratoAssinadoNotificationHandler : IRequestHandler<ContratoAssinadoNotification>
{
    public Task Handle(ContratoAssinadoNotification notification, CancellationToken cancellationToken)
    {
        
    }
}

public record ContratoAssinadoNotification(int propostaId) : INotification { }
