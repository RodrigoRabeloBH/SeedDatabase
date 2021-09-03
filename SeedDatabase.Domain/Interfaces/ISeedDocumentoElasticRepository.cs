using SeedDatabase.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeedDatabase.Domain.Interfaces
{
    public interface ISeedDocumentoElasticRepository
    {
        Task SeedData(IEnumerable<Documento> documentos);
    }
}
