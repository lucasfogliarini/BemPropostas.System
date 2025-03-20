using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BemPropostas.Infrastructure.EntityConfigurations;

public class PropostasConfiguration : IEntityTypeConfiguration<Propostas>
{
    public void Configure(EntityTypeBuilder<Propostas> builder)
    {
        builder.HasKey(o => o.Id);
    }
}
