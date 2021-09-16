using System;

namespace SeedDatabase.Domain.Models
{
    public class Pessoa_PF
    {
        public Guid Id_Pessoa_PF { get; set; }
        public int Id_Profissao { get; set; }
        public int Id_Estado_Civil { get; set; }
        public string Cd_Sexo { get; set; }
        public int? Id_Genero { get; set; }
        public int? Id_Cargo { get; set; }
        public int? Id_Area { get; set; }
        public string Nom_Social { get; set; }
        public int Qtd_Filhos { get; set; }
        public DateTime Dt_Nascimento { get; set; }
        public DateTime Dt_Alteracao_Registro { get; set; }
        public bool? Idc_Politicamente_Exposta { get; set; }
        public bool? Idc_Terrorista { get; set; }

        // Entity Relation

        // [ForeignKey("id_pessoa")]
        // public Guid Id_Pessoa { get; set; }
        // public Pessoa Pessoa { get; set; }
    }
}
