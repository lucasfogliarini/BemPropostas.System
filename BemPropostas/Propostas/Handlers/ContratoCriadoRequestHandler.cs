using MediatR;

namespace BemPropostas.Handlers;

public class ContratoCriadoRequestHandler : IRequestHandler<ContratoCriadoRequest>
{
    public Task Handle(ContratoCriadoRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public record ContratoCriadoRequest(int contratoId) : IRequest { }
