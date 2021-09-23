using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Data.Repository.SqlServer
{
    public class DapperPessoaRepository : IDapperPessoaRepository
    {
        private readonly string _connectionString;
        protected readonly IConfiguration _config;
        protected readonly ILogger<DapperPessoaRepository> _logger;

        public DapperPessoaRepository(IConfiguration config, ILogger<DapperPessoaRepository> logger)
        {
            _config = config;
            _logger = logger;
            _connectionString = _config.GetConnectionString("DefaultConnection");
        }

        public async Task Delete(Guid id)
        {
            try
            {
                string sql = @"UPDATE pessoa SET dt_exclusao_registro = @dt_exclusao_registro WHERE id_pessoa = @id_pessoa";

                using (var conn = new SqlConnection(_connectionString))
                {
                    var parametros = new DynamicParameters();

                    parametros.Add("id_pessoa", id);

                    await conn.ExecuteAsync(sql, parametros);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public async Task<IEnumerable<Pessoa>> FindAll()
        {
            IEnumerable<Pessoa> pessoas = null;

            try
            {
                string sql = "SELECT TOP 1000 * FROM PESSOA";

                using (var conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    pessoas = await conn.QueryAsync<Pessoa>(sql);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return pessoas;
        }
        public async Task<Pessoa> FindById(Guid id)
        {
            Pessoa pessoa = null;

            try
            {
                string sql = "SELECT * FROM PESSOA WHERE ID_PESSOA = @ID_PESSO";

                using (var conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    var parametros = new DynamicParameters();

                    parametros.Add("id_pessoa", id);

                    pessoa = await conn.QueryFirstOrDefaultAsync<Pessoa>(sql);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return pessoa;
        }
        public async Task InsertOne(Pessoa pessoa)
        {
            try
            {
                string sql = @$"INSERT INTO PESSOA (id_pessoa, 
                                                    id_situacao_pessoa, 
                                                    tipo_pessoa, 
                                                    nom_nome,
                                                    dt_inclusao_registro, 
                                                    dt_alteracao_registro,
                                                    cd_resp_inclusao )                           
                                            VALUES (NEWID(),
                                                    @id_situacao_pessoa,
                                                    @tipo_pessoa,
                                                    @nom_nome,
                                                    GETDATE(),
                                                    GETDATE(),
                                                    @cd_resp_inclusao)";

                var parametros = new DynamicParameters();

                parametros.Add("id_situacao_pessoa", pessoa.Id_Situacao_Pessoa);
                parametros.Add("tipo_pessoa", pessoa.Tipo_Pessoa);
                parametros.Add("nom_nome", pessoa.Nom_Nome);
                parametros.Add("cd_resp_inclusao", pessoa.Cd_Resp_Inclusao);

                using (var conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    await conn.ExecuteAsync(sql, parametros);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public void Insert(Pessoa pessoa)
        {
            try
            {
                string sql = @$"INSERT INTO PESSOA (id_pessoa, 
                                                    id_situacao_pessoa, 
                                                    tipo_pessoa, 
                                                    nom_nome,
                                                    dt_inclusao_registro, 
                                                    dt_alteracao_registro,
                                                    cd_resp_inclusao )                           
                                            VALUES (NEWID(),
                                                    @id_situacao_pessoa,
                                                    @tipo_pessoa,
                                                    @nom_nome,
                                                    GETDATE(),
                                                    GETDATE(),
                                                    @cd_resp_inclusao)";

                var parametros = new DynamicParameters();

                parametros.Add("id_situacao_pessoa", pessoa.Id_Situacao_Pessoa);
                parametros.Add("tipo_pessoa", pessoa.Tipo_Pessoa);
                parametros.Add("nom_nome", pessoa.Nom_Nome);
                parametros.Add("cd_resp_inclusao", pessoa.Cd_Resp_Inclusao);

                using (var conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    conn.Execute(sql, parametros);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public async Task UpdateAsync(Pessoa pessoa)
        {
            try
            {
                string sql = @"UPDATE pessoa SET  id_situacao_pessoa = @id_situacao_pessoa,
                                                id_motivo_cancelamento = @id_motivo_cancelamento,
                                                id_canal_inclusao = @id_canal_inclusao,
                                                cd_pais = @cd_pais,
                                                tipo_pessoa = @tipo_pessoa,
                                                nom_nome = @nom_nome,
                                                dt_alteracao_registro = @dt_alteracao_registro,
                                                cd_resp_inclusao = @cd_resp_inclusao,
                                                desc_motivo_cancelamento = @desc_motivo_cancelamento,
                                                txt_observacao = @txt_observacao
                            WHERE id_pessoa = @id_pessoa";

                DynamicParameters parametros = new DynamicParameters();

                parametros.Add("id_pessoa", pessoa.Id_Pessoa);
                parametros.Add("id_situacao_pessoa", pessoa.Id_Situacao_Pessoa);
                parametros.Add("id_motivo_cancelamento", pessoa.Id_Motivo_Cancelamento);
                parametros.Add("id_canal_inclusao", pessoa.Id_Canal_Inclusao);
                parametros.Add("cd_pais", pessoa.Cd_Pais);
                parametros.Add("tipo_pessoa", pessoa.Tipo_Pessoa);
                parametros.Add("nom_nome", pessoa.Nom_Nome);
                parametros.Add("dt_alteracao_registro", DateTime.Now);
                parametros.Add("cd_resp_inclusao", pessoa.Cd_Resp_Inclusao);
                parametros.Add("desc_motivo_cancelamento", pessoa.Desc_Motivo_Cancelamento);
                parametros.Add("txt_observacao", pessoa.Txt_Observacao);

                using (var conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    await conn.ExecuteAsync(sql, parametros);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
        public void Update(Pessoa pessoa)
        {
            try
            {
                string sql = @"UPDATE pessoa SET  id_situacao_pessoa = @id_situacao_pessoa,
                                                id_motivo_cancelamento = @id_motivo_cancelamento,
                                                id_canal_inclusao = @id_canal_inclusao,
                                                cd_pais = @cd_pais,
                                                tipo_pessoa = @tipo_pessoa,
                                                nom_nome = @nom_nome,
                                                dt_alteracao_registro = @dt_alteracao_registro,
                                                cd_resp_inclusao = @cd_resp_inclusao,
                                                desc_motivo_cancelamento = @desc_motivo_cancelamento,
                                                txt_observacao = @txt_observacao
                            WHERE id_pessoa = @id_pessoa";

                DynamicParameters parametros = new DynamicParameters();

                parametros.Add("id_pessoa", pessoa.Id_Pessoa);
                parametros.Add("id_situacao_pessoa", pessoa.Id_Situacao_Pessoa);
                parametros.Add("id_motivo_cancelamento", pessoa.Id_Motivo_Cancelamento);
                parametros.Add("id_canal_inclusao", pessoa.Id_Canal_Inclusao);
                parametros.Add("cd_pais", pessoa.Cd_Pais);
                parametros.Add("tipo_pessoa", pessoa.Tipo_Pessoa);
                parametros.Add("nom_nome", pessoa.Nom_Nome);
                parametros.Add("dt_alteracao_registro", DateTime.Now);
                parametros.Add("cd_resp_inclusao", pessoa.Cd_Resp_Inclusao);
                parametros.Add("desc_motivo_cancelamento", pessoa.Desc_Motivo_Cancelamento);
                parametros.Add("txt_observacao", pessoa.Txt_Observacao);

                using (var conn = new SqlConnection(_connectionString))
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    conn.Execute(sql, parametros);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}