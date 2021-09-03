using SeedDatabase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeedDatabase.Domain.Interfaces
{
    public interface ISeedPessoaPFElasticRepository
    {
        Task SeedData(IEnumerable<Pessoa_PF> pessoas);
    }
}
