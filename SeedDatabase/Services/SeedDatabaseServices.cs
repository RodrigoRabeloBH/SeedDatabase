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
            List<Pessoa_PF> persons = new List<Pessoa_PF>();

            Guid idPessoa = Guid.Parse("0C45DA46-7519-45C5-B0B9-000005D3D8A6");

            try
            {
                for (int i = 0; i < quantity; i++)
                {
                    var person = new Pessoa_PF
                    {
                        Cd_Sexo = "M",
                        Dt_Alteracao_Registro = DateTime.UtcNow,
                        Dt_Nascimento = DateTime.Parse("02/09/1992"),
                        Id_Area = null,
                        Id_Cargo = 1,
                        Id_Estado_Civil = 2,
                        Id_Genero = 2,
                        Id_Profissao = 1,
                        Idc_Politicamente_Exposta = null,
                        Idc_Terrorista = null,
                        Nom_Social = "Pessoa " + idPessoa.ToString(),
                        Qtd_Filhos = 1
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
        public IEnumerable<Pessoa_PJ> BuildPersonPJList(int quantity)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Documento> BuildDocumentList(int quantity)
        {
            List<Documento> documentos = new List<Documento>();

            Guid idPessoa = Guid.Parse("B81CD9AA-F23F-4B5B-AC54-00001F4EB09E");

            try
            {
                for (int i = 0; i <= quantity; i++)
                {
                    var documento = new Documento
                    {
                        Cd_Documento_Eletronico = Guid.NewGuid(),
                        Cd_Pais = "0055",
                        Cd_Resp_Inclusao = "AC",
                        Cd_Tipo_Documento_Eletronico = "aabb",
                        Desc_Orgao_Emissor = "SSP",
                        Dt_Alteracao_Registro = DateTime.UtcNow,
                        Dt_Emissao = DateTime.Now,
                        Dt_Exclusao_Registro = null,
                        Dt_Expiracao = DateTime.Now.AddDays(30),
                        Dt_Inclusao_Registro = DateTime.UtcNow,
                        Id_Documento = Guid.NewGuid(),
                        Id_Pessoa = idPessoa,
                        Id_Tipo_Documento = 1,
                        Num_Documento = "7945613" + i,
                        Sigla_Estado = "SP"
                    };

                    documentos.Add(documento);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return documentos;
        }
    }
}
