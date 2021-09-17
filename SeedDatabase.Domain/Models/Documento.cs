using System;

namespace SeedDatabase.Domain.Models
{
    public class Documento
    {
        public Guid Id_Documento { get; set; }
        public short Id_Tipo_Documento { get; set; }
        public string Num_Documento { get; set; }
        public string Cd_Pais { get; set; }
        public string Sigla_Estado { get; set; }
        public DateTime Dt_Emissao { get; set; }
        public DateTime Dt_Expiracao { get; set; }
        public string Desc_Orgao_Emissor { get; set; }
        public string Cd_Tipo_Documento_Eletronico { get; set; }
        public Guid Cd_Documento_Eletronico { get; set; }
        public string Cd_Resp_Inclusao { get; set; }
        public DateTime Dt_Inclusao_Registro { get; set; }
        public DateTime? Dt_Alteracao_Registro { get; set; }
        public DateTime? Dt_Exclusao_Registro { get; set; }
        public Guid Id_Pessoa { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}