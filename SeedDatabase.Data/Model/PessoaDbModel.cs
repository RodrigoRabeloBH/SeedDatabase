using System;
using SeedDatabase.Domain.Models;

namespace SeedDatabase.Data.Model
{
    [BsonCollection("Pessoa")]
    public class PessoaDbModel : Document
    {
        public Guid Id_Pessoa { get; set; }
        public int Id_Situacao_Pessoa { get; set; }
        public int? Id_Motivo_Cancelamento { get; set; }
        public Guid Id_Canal_Inclusao { get; set; }
        public string Cd_Pais { get; set; }
        public string Tipo_Pessoa { get; set; }
        public string Nom_Nome { get; set; }
        public DateTime Dt_Inclusao_Registro { get; set; }
        public DateTime? Dt_Alteracao_Registro { get; set; }
        public DateTime? Dt_Exclusao_Registro { get; set; }
        public string Cd_Resp_Inclusao { get; set; }
        public string Desc_Motivo_Cancelamento { get; set; }
        public string Txt_Observacao { get; set; }
    }
}