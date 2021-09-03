using System.Threading.Tasks;

namespace SeedDatabase.Domain.Interfaces
{
    public interface ISeedDatabaseSQLServerServices
    {
        Task InsertPersons(int quantity);
        Task InsertPersonsPF(int quantity);
        Task InsertDocuments(int quantity);
    }
}