using AutoMapper;
using SeedDatabase.Data.Model;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PessoaDbModel, Pessoa>().ReverseMap();
            CreateMap<DocumentoDbModel, Documento>().ReverseMap();
        }
    }
}