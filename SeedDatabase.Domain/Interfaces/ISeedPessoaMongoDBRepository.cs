using System.Collections.Generic;
using System.Threading.Tasks;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Domain.Interfaces
{
    public interface ISeedPessoaMongoDBRepository
    {
        Task SeedData(IEnumerable<Pessoa> pessoas);
    }
}