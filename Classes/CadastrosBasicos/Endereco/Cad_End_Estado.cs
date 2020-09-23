using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Classes
{
    public class Cad_End_Estado : Padrao
    {
        public string Nome { get; set; }

        [DisplayName("Estado")]
        public string Sigla { get; set; }
    }
}
