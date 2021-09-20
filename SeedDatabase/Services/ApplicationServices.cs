using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SeedDatabase.Data.Model;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Services
{
    public class ApplicationServices : IApplicationServices
    {
        private readonly ILogger<ApplicationServices> _logger;
        private readonly ISeedDatabaseServices _services;
        private readonly IMongoRepository<PessoaDbModel> _mongoPessoaRepository;
        private readonly ISqlRepository<Pessoa> _sqlPessoaRepository;
        private readonly ISqlRepository<Documento> _sqlDocumentoRepository;
        private readonly IMongoRepository<DocumentoDbModel> _mongoDocumentoRepository;
        private readonly IMapper _mapper;

        public ApplicationServices(ILogger<ApplicationServices> logger, ISeedDatabaseServices services,
            IMongoRepository<PessoaDbModel> mongoPessoaRepository, ISqlRepository<Pessoa> sqlPessoaRepository,
            ISqlRepository<Documento> sqlDocumentoRepository, IMongoRepository<DocumentoDbModel> mongoDocumentoRepository, IMapper mapper)
        {
            _logger = logger;
            _services = services;
            _mongoPessoaRepository = mongoPessoaRepository;
            _sqlPessoaRepository = sqlPessoaRepository;
            _sqlDocumentoRepository = sqlDocumentoRepository;
            _mongoDocumentoRepository = mongoDocumentoRepository;
            _mapper = mapper;
        }
        public async Task RunMongoTest(int buildQuantity)
        {
            _logger.LogInformation("Inicio dos testes Mongo: {time} ", DateTimeOffset.Now);

            Stopwatch stopWatch = new Stopwatch();

            var peoples = _mapper.Map<IEnumerable<PessoaDbModel>>(_services.BuildPersonList(buildQuantity));

            var id = Guid.Parse("62eeedd3-b8e7-424c-9398-7a9c2826a8b6");

            stopWatch.Start();

            var pessoa = await _mongoPessoaRepository.FindOneAsync(p => p.Id_Pessoa == id);

            var pessoas = await _mongoPessoaRepository.GetAll();

            stopWatch.Stop();

            _logger.LogInformation("Testes executados em: {time} segundos", stopWatch.ElapsedMilliseconds / 1000);
        }
        public async Task RunSQLServerTest(int buildQuantity)
        {
            _logger.LogInformation("Inicio dos testes SQL Server: {time} ", DateTimeOffset.Now);

            Stopwatch stopWatch = new Stopwatch();

            var id = Guid.Parse("82A5C81B-4401-4914-B725-00000AF4A5EE");

            stopWatch.Start();

            var pessoa = await _sqlPessoaRepository.FindOne(p => p.Id_Pessoa == id);

            string pessoaJson = JsonConvert.SerializeObject(pessoa);

            var pessoaClass = JsonConvert.DeserializeObject<Pessoa>(pessoaJson);

            var pessoas = await _sqlPessoaRepository.FindAll();

            stopWatch.Stop();

            _logger.LogInformation("Testes executados em: {time} segundos", stopWatch.ElapsedMilliseconds / 1000);
        }
    }
}