using System.Data;
using System.Threading.Tasks;

namespace SeedDatabase.Domain.Interfaces
{
    public interface IDataFactory
    {
        IDbConnection OpenConnection(string conn = null);
        Task<IDbConnection> OpenConnectionAsync(string conn = null);
    }
}