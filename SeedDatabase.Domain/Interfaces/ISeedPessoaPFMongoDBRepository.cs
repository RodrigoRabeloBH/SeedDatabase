using SeedDatabase.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeedDatabase.Domain.Interfaces
{
    public interface ISeedPessoaPFMongoDBRepository
    {
        Task SeedData(IEnumerable<Pessoa_PF> pessoas);
    }
}
