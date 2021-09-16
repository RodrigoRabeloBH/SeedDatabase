using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SeedDatabase.Data.Model;
using SeedDatabase.Domain.Interfaces;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Services
{
    public class ApplicationServices : IApplicationServices
    {
        private readonly ILogger<ApplicationServices> _logger;
        private readonly ISeedDatabaseServices _services;
        private readonly IMongoRepository<DocumentoDbModel> _mongoDocumentoRepository;
        private readonly IMongoRepository<PessoaDbModel> _mongoPessoaRepository;
        private readonly ISqlRepository<Pessoa> _sqlPessoaRepository;
        private readonly ISqlRepository<Documento> _sqlDocumentoRepository;
        private readonly IMapper _mapper;

        public ApplicationServices(ILogger<ApplicationServices> logger, ISeedDatabaseServices services,
                                   IMongoRepository<DocumentoDbModel> mongoDocumentoRepository, IMongoRepository<PessoaDbModel> mongoPessoaRepository,
                                   ISqlRepository<Pessoa> sqlPessoaRepository, ISqlRepository<Documento> sqlDocumentoRepository,
                                   IMapper mapper)
        {
            _logger = logger;
            _services = services;
            _mongoDocumentoRepository = mongoDocumentoRepository;
            _mongoPessoaRepository = mongoPessoaRepository;
            _sqlPessoaRepository = sqlPessoaRepository;
            _sqlDocumentoRepository = sqlDocumentoRepository;
            _mapper = mapper;
        }

        public async Task RunMongoTest(int buildQuantity)
        {
            _logger.LogInformation("Inicio dos testes Mongo: {time} ", DateTimeOffset.Now);

            Stopwatch stopWatch = new Stopwatch();

            var peoples = _mapper.Map<IEnumerable<PessoaDbModel>>(_services.BuildPersonList(buildQuantity));

            var id = peoples.FirstOrDefault().Id_Pessoa;

            var documents = _mapper.Map<IEnumerable<DocumentoDbModel>>(_services.BuildDocumentList(buildQuantity, id));

            stopWatch.Start();

            await _mongoPessoaRepository.InsertManyAsync(peoples);

            await _mongoDocumentoRepository.InsertManyAsync(documents);

            var pessoas = await _mongoPessoaRepository.GetAll();

            var documentos = await _mongoDocumentoRepository.GetAll();

            stopWatch.Stop();

            _logger.LogInformation("Testes executados em: {time} segundos", stopWatch.ElapsedMilliseconds / 1000);
        }
        public async Task RunSQLServerTest(int buildQuantity)
        {
            _logger.LogInformation("Inicio dos testes SQL Server: {time} ", DateTimeOffset.Now);

            Stopwatch stopWatch = new Stopwatch();

            var peoples = _services.BuildPersonList(buildQuantity);

            var id = peoples.FirstOrDefault().Id_Pessoa;

            var documents = _services.BuildDocumentList(buildQuantity, id);

            stopWatch.Start();

            await _sqlPessoaRepository.InsertMany(peoples);

            await _sqlDocumentoRepository.InsertMany(documents);

            // var pessoas = await _sqlPessoaRepository.FindAll();

            // var documentos = await _sqlDocumentoRepository.FindAll();

            stopWatch.Stop();

            _logger.LogInformation("Testes executados em: {time} segundos", stopWatch.ElapsedMilliseconds / 1000);
        }
    }
}