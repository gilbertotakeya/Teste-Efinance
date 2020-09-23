using Classes;
using Classes.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Repositorio
{
    public class Cli_ClienteRepositorio : ICli_ClienteRepositorio
    {
        private readonly ContextoConexaoBancoDeDados _context;

        public Cli_ClienteRepositorio(ContextoConexaoBancoDeDados context)
        {
            _context = context;
        }

        public bool ValidarCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");

            valor = valor.Replace("-", "");

            if (valor.Length != 11)

                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;



            if (igual || valor == "12345678909")

                return false;



            int[] numeros = new int[11];



            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(

                  valor[i].ToString());



            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];



            int resultado = soma % 11;



            if (resultado == 1 || resultado == 0)

            {

                if (numeros[9] != 0)

                    return false;

            }

            else if (numeros[9] != 11 - resultado)

                return false;



            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];



            resultado = soma % 11;



            if (resultado == 1 || resultado == 0)

            {

                if (numeros[10] != 0)

                    return false;

            }

            else

                if (numeros[10] != 11 - resultado)

                return false;



            return true;

        }

        public async Task<List<Cli_Cliente>> ListarAsync()
        {
            try
            {
                var lista = await _context.Cli_Cliente.ToListAsync();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Obsolete]
        public async Task<List<ListagemClienteViewModel>> ListarProcAsync()
        {
            try
            {                
                var lista = await _context.Query<ListagemClienteViewModel>().AsNoTracking().FromSql(string.Format("EXEC {0}", "PROC_CLI_LISTAGEM_V1")).ToListAsync();
                //_context.Set<ListagemClienteViewModel>().FromSql<ListagemClienteViewModel>("EXEC PROC_CLI_LISTAGEM_V1").ToListAsync();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cli_Cliente> ObterAsync(int Id)
        {
            try
            {
                var obj = await _context.Cli_Cliente
                                        .Where(f => f.Id == Id)
                                        .Include(w=>w.Estado)
                                        .Include(w=>w.Cidade)
                                        .Include(w => w.Endereco)
                                        .FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cli_Cliente> CriarAsync(Cli_Cliente modelo)
        {
            try
            {
                if (!ValidarCPF(modelo.CPF))
                    throw new SystemException("Informe um CPF válido");

                modelo.DataInclusao = DateTime.Now;
                _context.Add(modelo);
                await _context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cli_Cliente> EditarAsync(Cli_Cliente modelo)
        {
            try
            {
                if (!ValidarCPF(modelo.CPF))
                    throw new SystemException("Informe um CPF válido");

                _context.Update(modelo);
                await _context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeletarAsync(Cli_Cliente modelo)
        {
            try
            {
                modelo.DataExclusao = DateTime.Now;
                _context.Cli_Cliente.Update(modelo);
                //_context.Cli_Cliente.Remove(modelo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SelectList GerarSelectList(int? Id)
        {
            SelectList listagem = new SelectList(_context.Cli_Cliente, "Id", "Nome");

            if (Id.HasValue)
            {
                listagem = new SelectList(_context.Cli_Cliente, "Id", "Nome", Id);
            }

            return listagem;
        }
    }
}
