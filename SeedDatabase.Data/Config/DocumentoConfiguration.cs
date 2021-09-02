using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Data.Config
{
    public class DocumentoConfiguration : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.HasKey(d => d.Id_Documento);
            builder.HasOne(d => d.Pessoa).WithMany().HasForeignKey(d => d.Id_Pessoa);
        }
    }
}