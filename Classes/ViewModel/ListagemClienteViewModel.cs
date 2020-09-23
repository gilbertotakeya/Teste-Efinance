using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Classes.ViewModel
{
    public class ListagemClienteViewModel
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string NomeApresentacao { get; set; }

        [DisplayName("Data de nascimento")]
        public DateTime? DataNascimento { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        [DisplayName("Contato")]
        public string NumeroTelefone { get; set; }

        [DisplayName("Endereço")]
        public string Endereco { get; set; }
    }
}
