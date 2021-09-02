using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Data.Context
{
    public class SeedDatabaseContext : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Pessoa_PF> Pessoa_PF { get; set; }
        public DbSet<Pessoa_PJ> Pessoa_PJ { get; set; }
        public DbSet<Documento> Documento { get; set; }
        public SeedDatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
