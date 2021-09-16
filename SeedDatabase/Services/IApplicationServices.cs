using System.Threading.Tasks;

namespace SeedDatabase.Services
{
    public interface IApplicationServices
    {
        Task RunMongoTest(int buildQuantity);
        Task RunSQLServerTest(int buildQuantity);
    }
}