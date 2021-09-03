using System.Threading.Tasks;

namespace SeedDatabase.Domain.Interfaces
{
    public interface ISeedDatabaseElasticSearchServices
    {
        Task InsertPersons(int quantity);
        Task InsertPersonsPF(int quantity);
        Task InsertDocuments(int quantity);
    }
}