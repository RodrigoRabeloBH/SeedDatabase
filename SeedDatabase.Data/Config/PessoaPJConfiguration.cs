using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Data.Config
{
    public class PessoaPJConfiguration : IEntityTypeConfiguration<Pessoa_PJ>
    {
        public void Configure(EntityTypeBuilder<Pessoa_PJ> builder)
        {
            builder.HasKey(pj => pj.Id_Pessoa_PJ);
        }
    }
}