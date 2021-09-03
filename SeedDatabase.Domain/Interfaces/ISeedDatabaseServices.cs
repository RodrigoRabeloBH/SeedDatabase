using SeedDatabase.Domain.Models;
using System.Collections.Generic;

namespace SeedDatabase.Domain.Interfaces
{
    public interface ISeedDatabaseServices
    {
        IEnumerable<Pessoa> BuildPersonList(int quantity);
        IEnumerable<Pessoa_PF> BuildPersonPFList(int quantity);
        IEnumerable<Pessoa_PJ> BuildPersonPJList(int quantity);
        IEnumerable<Documento> BuildDocumentList(int quantity);
    }
}
