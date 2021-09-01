using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeedDatabase.Domain.Interfaces
{
    public interface ISeedDatabaseRepository<T> where T : class
    {
        Task SeedData(IEnumerable<T> data);
    }
}
