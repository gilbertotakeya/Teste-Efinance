using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Classes
{
    public class Cad_End_Estado : Padrao
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo {0} atingiu a quantidade de caracteres(50)")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(2, ErrorMessage = "O campo {0} atingiu a quantidade de caracteres(2)")]
        [DisplayName("Sigla")]
        public string Sigla { get; set; }
    }
}