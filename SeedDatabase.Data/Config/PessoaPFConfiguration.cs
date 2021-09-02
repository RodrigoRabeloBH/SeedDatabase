using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Data.Config
{
    public class PessoaPFConfiguration : IEntityTypeConfiguration<Pessoa_PF>
    {
        public void Configure(EntityTypeBuilder<Pessoa_PF> builder)
        {
            builder.HasKey(p => new { p.Id_Pessoa_PF });
        }
    }
}