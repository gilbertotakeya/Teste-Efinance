using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Classes
{
    public class Cad_End_Cidade : Padrao
    {
        [DisplayName("Cidade")]
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public Cad_End_Estado Estado { get; set; }

        public string CodigoIBGE { get; set; }
    }
}