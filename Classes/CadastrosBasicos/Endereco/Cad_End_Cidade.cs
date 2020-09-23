using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Classes
{
    public class Cad_End_Cidade : Padrao
    {
        [DisplayName("Cidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int EstadoId { get; set; }
        public Cad_End_Estado Estado { get; set; }

        [DisplayName("Código IBGE")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CodigoIBGE { get; set; }
    }
}