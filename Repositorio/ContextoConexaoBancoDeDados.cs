using Classes;
using Classes.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio
{
    public class ContextoConexaoBancoDeDados : DbContext
    {
        public ContextoConexaoBancoDeDados(DbContextOptions<ContextoConexaoBancoDeDados> opcoes) : base (opcoes)
        {

        }

        public DbSet<Cad_End_Cidade> Cad_End_Cidade { get; set; }
        public DbSet<Cad_End_Endereco> Cad_End_Endereco { get; set; }
        public DbSet<Cad_End_Estado> Cad_End_Estado { get; set; }
        public DbSet<Cli_Cliente> Cli_Cliente { get; set; }

        public virtual DbSet<ListagemClienteViewModel> ListagemClienteViewModel { get; set; }

    }
}
