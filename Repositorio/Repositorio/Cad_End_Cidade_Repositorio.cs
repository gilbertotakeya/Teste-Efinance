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
    public class Cad_End_Cidade_Repositorio : ICad_End_Cidade_Repositorio
    {
        private readonly ContextoConexaoBancoDeDados _context;

        public Cad_End_Cidade_Repositorio(ContextoConexaoBancoDeDados context)
        {
            _context = context;
        }

        public async Task<List<Cad_End_Cidade>> ListarAsync()
        {
            try
            {
                var lista = await _context.Cad_End_Cidade.Include(f => f.Estado).ToListAsync();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<Cad_End_Cidade>> ListarCidadeAsync(string pesquisaCidade)
        {
            try
            {
                var lista = await _context.Cad_End_Cidade
                                          .Where(f=> f.Nome.ToUpper().Contains(pesquisaCidade.ToUpper()))
                                          .Include(f => f.Estado).ToListAsync();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cad_End_Cidade> ObterAsync(int Id)
        {
            try
            {
                var obj = await _context.Cad_End_Cidade
                                        .Where(f => f.Id == Id)
                                        .Include(f => f.Estado)
                                        .FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<Cad_End_Cidade> ObterAsync(string CodigoIBGE)
        {
            try
            {
                var obj = await _context.Cad_End_Cidade
                                        .Where(f => f.CodigoIBGE.ToUpper() == CodigoIBGE.ToUpper())
                                        .Include(f => f.Estado)
                                        .FirstOrDefaultAsync();
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<Cad_End_Cidade> CriarAsync(Cad_End_Cidade modelo)
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

        public async Task<Cad_End_Cidade> EditarAsync(Cad_End_Cidade modelo)
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

        public async Task<bool> DeletarAsync(Cad_End_Cidade modelo)
        {
            try
            {
                _context.Cad_End_Cidade.Remove(modelo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<SelectListItem> GerarSelectList(int? Id)
        {
            var listagem = _context.Cad_End_Cidade
                                   .Select(c => new SelectListItem()
                                                { 
                                                    Text = c.Nome, 
                                                    Value = c.Id.ToString() 
                                                })
                                   .ToList();

            return listagem;
        }
    }
}
