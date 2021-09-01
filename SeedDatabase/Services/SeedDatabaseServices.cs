using Microsoft.Extensions.Logging;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;
using System;
using System.Collections.Generic;

namespace SeedDatabase.Services
{
    public class SeedDatabaseServices : ISeedDatabaseServices
    {
        private readonly ILogger<SeedDatabaseServices> _logger;
        public SeedDatabaseServices(ILogger<SeedDatabaseServices> logger)
        {
            _logger = logger;
        }
        public IEnumerable<Pessoa> BuildPersonList(int quantity)
        {
            List<Pessoa> persons = new List<Pessoa>();

            Guid idCanal = Guid.Parse("27E73182-805D-4949-A029-3F00D2A498A8");

            try
            {
                for (int i = 0; i < quantity; i++)
                {
                    var person = new Pessoa
                    {
                        Id_Pessoa = Guid.NewGuid(),
                        Cd_Pais = "0055",
                        Desc_Motivo_Cancelamento = null,
                        Dt_Alteracao_Registro = DateTime.UtcNow,
                        Dt_Inclusao_Registro = DateTime.UtcNow,
                        Id_Canal_Inclusao = idCanal,
                        Id_Motivo_Cancelamento = null,
                        Id_Situacao_Pessoa = 1,
                        Nom_Nome = "Pessoa " + i,
                        Cd_Resp_Inclusao = "AC",
                        Tipo_Pessoa = "F",
                        Txt_Observacao = null
                    };
                    persons.Add(person);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return persons;
        }

        public IEnumerable<Pessoa_PF> BuildPersonPFList(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pessoa_PJ> BuildPersonPJList(int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
