using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Services
{
    public class DapperPessoaServices : IDapperPessoaServices
    {
        private readonly IDapperPessoaRepository _rep;
        private readonly ILogger<DapperPessoaServices> _logger;
        private readonly ISeedDatabaseServices _services;

        public DapperPessoaServices(IDapperPessoaRepository rep, ILogger<DapperPessoaServices> logger, ISeedDatabaseServices services)
        {
            _rep = rep;
            _logger = logger;
            _services = services;
        }
        public async Task InsertPessoaAsyncSqlDapperTeste(int qtd)
        {
            _logger.LogInformation("Inicio dos testes INSERT SQL com Dapper: {time} ", DateTimeOffset.Now);

            Stopwatch stopWatch = new Stopwatch();

            var pessoas = _services.BuildPersonList(qtd);

            stopWatch.Start();

            foreach (var pessoa in pessoas)
            {
                await _rep.InsertOne(pessoa);
            }

            stopWatch.Stop();

            _logger.LogInformation("Testes executados em: {time} segundos", stopWatch.ElapsedMilliseconds / 1000);
        }
        public void InsertPessoaParallelSqlDapperTeste(int qtd)
        {
            _logger.LogInformation("Inicio dos testes INSERT SQL com Dapper: {time} ", DateTimeOffset.Now);

            Stopwatch stopWatch = new Stopwatch();

            var pessoas = _services.BuildPersonList(qtd);

            stopWatch.Start();

            Parallel.ForEach(pessoas, (pessoa) =>
            {
                _rep.Insert(pessoa);
            });

            stopWatch.Stop();

            _logger.LogInformation("Testes executados em: {time} segundos", stopWatch.ElapsedMilliseconds / 1000);
        }
        public async Task UpdatePessoasAsyncDapperTeste(IEnumerable<Pessoa> pessoas)
        {
            _logger.LogInformation("Inicio dos testes de UPDATE SQL com Dapper: {time} ", DateTimeOffset.Now);

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            foreach (var pessoa in pessoas)
            {
                await _rep.UpdateAsync(pessoa);
            }

            stopWatch.Stop();

            _logger.LogInformation("Testes executados em: {time} segundos", stopWatch.ElapsedMilliseconds / 1000);
        }
        public void UpdatePessoasParallelDapperTeste(IEnumerable<Pessoa> pessoas)
        {
            _logger.LogInformation("Inicio dos testes de UPDATE SQL com Dapper: {time} ", DateTimeOffset.Now);

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            Parallel.ForEach(pessoas, (p) =>
            {
                p.Nom_Nome = "Teste de Update" + Guid.NewGuid().ToString();

                _rep.Update(p);
            });

            stopWatch.Stop();

            _logger.LogInformation("Testes executados em: {time} segundos", stopWatch.ElapsedMilliseconds / 1000);
        }
        public async Task<IEnumerable<Pessoa>> SelectPessoasDapperTeste()
        {
            _logger.LogInformation("Inicio dos testes de SELECT * SQL com Dapper: {time} ", DateTimeOffset.Now);

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            var pessoas = await _rep.FindAll();

            stopWatch.Stop();

            _logger.LogInformation("Testes executados em: {time} segundos", stopWatch.ElapsedMilliseconds / 1000);

            return pessoas;
        }
        public async Task<Pessoa> SelectPessoasByIdDapperTeste(Guid id)
        {
            _logger.LogInformation("Inicio dos testes de SELECT BY ID SQL com Dapper: {time} ", DateTimeOffset.Now);

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();

            var pessoa = await _rep.FindById(id);

            stopWatch.Stop();

            _logger.LogInformation("Testes executados em: {time} segundos", stopWatch.ElapsedMilliseconds / 1000);

            return pessoa;
        }

    }
}