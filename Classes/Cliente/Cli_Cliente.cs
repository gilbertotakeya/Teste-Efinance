using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Classes
{
    public class Cli_Cliente : Padrao
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(200, ErrorMessage = "O campo {0} atingiu a quantidade de caracteres(200)" )]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [MaxLength(200, ErrorMessage = "O campo {0} atingiu a quantidade de caracteres(200)")]
        [DisplayName("Nome Social")]
        public string NomeSocial { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(20, ErrorMessage = "O campo {0} atingiu a quantidade de caracteres(20)")]
        [DisplayName("RG")]
        public string RG { get; set; }

        [MaxLength(14, ErrorMessage = "O campo {0} atingiu a quantidade de caracteres(14)")]
        [DisplayName("CPF")]
        public string CPF { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Nro Telefone principal")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NumeroTelefone { get; set; }

        [DisplayName("Nro Telefone 2")]
        public string NumeroTelefone2 { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Endereco")]
        public int EnderecoId { get; set; }
        public Cad_End_Endereco Endereco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Cidade")]
        public int CidadeId { get; set; }
        public Cad_End_Cidade Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Estado")] 
        public int EstadoId { get; set; }
        public Cad_End_Estado Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Numero")]
        public int Numero { get; set; }

        [DisplayName("Complemento")]
        public string Complemento { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }
    }
}
