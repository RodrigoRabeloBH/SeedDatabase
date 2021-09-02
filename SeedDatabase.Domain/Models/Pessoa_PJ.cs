using System;

namespace SeedDatabase.Domain.Models
{
    public class Pessoa_PJ
    {
        public Guid Id_Pessoa_PJ { get; set; }
        public string Id_Ramo_Atividade { get; set; }
        public DateTime Dt_Alteracao_Registro { get; set; }
        public string Nom_Fantasia { get; set; }
        public DateTime Dt_Fundacao { get; set; }
        public string Num_Inscricao_Municipal { get; set; }
        public string Num_Inscricao_Estadual { get; set; }
    }
}
