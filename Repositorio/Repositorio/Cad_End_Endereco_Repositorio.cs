using Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Repositorio
{
    public class Cad_End_Endereco_Repositorio : ICad_End_Endereco_Repositorio
    {
        private readonly ContextoConexaoBancoDeDados _context;

        public Cad_End_Endereco_Repositorio(ContextoConexaoBancoDeDados context)
        {
            _context = context;
        }

        public async Task<List<Cad_End_Endereco>> ListarAsync()
        {
            try
            {
                var lista = await _context.Cad_End_Endereco.ToListAsync();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cad_End_Endereco> ObterAsync(int Id)
        {
            try
            {
                var obj = await _context.Cad_End_Endereco.Include(f => f.EstadoId).FirstOrDefaultAsync(f => f.Id == Id);
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string RetirarFormatacaoCep(string cep)
        {
            return cep.Replace(".","").Replace("-", "").Trim().ToUpper();
        }
        public string RetirarEspaco(string variavel)
        {
            return variavel.Replace(" ", "").Trim().ToUpper();
        }
        public async Task<Cad_End_Endereco> ObterAsync(string CEP)
        {
            try
            {
                CEP = RetirarFormatacaoCep(CEP);
                var obj = await _context.Cad_End_Endereco
                                        .Where(w=> w.CEP == CEP)
                                        .Include(f => f.Estado)
                                        .FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cad_End_Endereco> ObterPorCodigoIGBEAsync(string CodigoIBGE)
        {
            try
            {
                CodigoIBGE = RetirarEspaco(CodigoIBGE);
                var obj = await _context.Cad_End_Endereco
                                        .Where(f => f.CodigoIBGE == CodigoIBGE)
                                        .Include(f => f.Estado)
                                        .FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cad_End_Endereco> CriarAsync(Cad_End_Endereco modelo)
        {
            try
            {
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

        public async Task<Cad_End_Endereco> EditarAsync(Cad_End_Endereco modelo)
        {
            try
            {
                _context.Update(modelo);
                _context.SaveChanges();
                return modelo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeletarAsync(Cad_End_Endereco modelo)
        {
            try
            {
                _context.Cad_End_Endereco.Remove(modelo);
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
            SelectList listagem = new SelectList(_context.Cad_End_Endereco, "Id", "Endereco");

            if (Id.HasValue)
            {
                listagem = new SelectList(_context.Cad_End_Endereco, "Id", "Endereco", Id);
            }

            return listagem;
        }
    }
}