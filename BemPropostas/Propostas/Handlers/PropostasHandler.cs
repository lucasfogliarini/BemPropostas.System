using MediatR;

namespace BemPropostas.Handlers;

public class ContratoCriadoHandler : IRequestHandler<ContratoCriadoCommand>
{
    public Task Handle(ContratoCriadoCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public record ContratoCriadoCommand(int propostaId) : IRequest { }
