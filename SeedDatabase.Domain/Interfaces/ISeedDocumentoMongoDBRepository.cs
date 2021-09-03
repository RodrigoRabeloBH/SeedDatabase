using SeedDatabase.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeedDatabase.Domain.Interfaces
{
    public interface ISeedDocumentoMongoDBRepository
    {
        Task SeedData(IEnumerable<Documento> documentos);
    }
}
