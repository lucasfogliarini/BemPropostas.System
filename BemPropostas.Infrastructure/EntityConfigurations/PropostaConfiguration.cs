using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BemPropostas.Infrastructure.EntityConfigurations;

public class PropostaConfiguration : IEntityTypeConfiguration<Proposta>
{
    public void Configure(EntityTypeBuilder<Proposta> builder)
    {
        builder.HasKey(o => o.Id);
    }
}
