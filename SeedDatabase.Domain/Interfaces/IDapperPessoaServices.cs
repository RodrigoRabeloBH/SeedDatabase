using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Domain.Interfaces
{
    public interface IDapperPessoaServices
    {
        Task InsertPessoaAsyncSqlDapperTeste(int qtd);
        void InsertPessoaParallelSqlDapperTeste(int qtd);
        Task UpdatePessoasAsyncDapperTeste(IEnumerable<Pessoa> pessoas);
        void UpdatePessoasParallelDapperTeste(IEnumerable<Pessoa> pessoas);
        Task<IEnumerable<Pessoa>> SelectPessoasDapperTeste();
        Task<Pessoa> SelectPessoasByIdDapperTeste(Guid id);
    }
}