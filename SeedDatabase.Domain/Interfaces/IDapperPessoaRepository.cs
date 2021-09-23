using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Domain.Interfaces
{
    public interface IDapperPessoaRepository
    {
        Task Delete(Guid id);
        Task<IEnumerable<Pessoa>> FindAll();
        Task<Pessoa> FindById(Guid id);
        Task InsertOne(Pessoa pessoa);
        void Insert(Pessoa pessoa);
        Task UpdateAsync(Pessoa pessoa);
        void Update(Pessoa pessoa);
    }
}