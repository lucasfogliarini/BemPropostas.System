using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;

using MediatR;
using BemPropostas.Handlers;

namespace BemPropostas.AzureFunctions
{
    public class ContratoCriadoFunction(IMediator mediator)
    {
        [FunctionName(nameof(ContratoCriadoFunction))]
        public void Run(
            [KafkaTrigger("BrokerList",
                          "contrato-criado",
                          Username = "$ConnectionString",
                          Password = "%KafkaPassword%",
                          Protocol = BrokerProtocol.SaslSsl,
                          AuthenticationMode = BrokerAuthenticationMode.Plain,
                          ConsumerGroup = "BemPropostas")] KafkaEventData<string>[] events,
            ILogger log)
        {
            var contratoCriado = new ContratoCriadoCommand(1);
            mediator.Send(contratoCriado);
        }
    }
}
