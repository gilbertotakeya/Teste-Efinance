using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Classes
{
    public class Cad_End_Endereco : Padrao
    {
        public int CidadeId { get; set; }
        public Cad_End_Cidade Cidade { get; set; }

        public int EstadoId { get; set; }

        [DisplayName("Estado")]
        public Cad_End_Estado Estado { get; set; }
        
        public string Endereco { get; set; }

        public string Bairro { get; set; }

        [DisplayName("IBGE")]
        public string CodigoIBGE { get; set; }

        [DisplayName("CEP")]
        public string CEP { get; set; }
    }
}
