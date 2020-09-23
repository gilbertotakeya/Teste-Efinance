using Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Repositorio
{
    public class Cad_End_Estado_Repositorio : ICad_End_Estado_Repositorio
    {
        private readonly ContextoConexaoBancoDeDados _context;

        public Cad_End_Estado_Repositorio(ContextoConexaoBancoDeDados context)
        {
            _context = context;
        }

        public async Task<List<Cad_End_Estado>> ListarAsync()
        {
            try
            {
                var lista = await _context.Cad_End_Estado.ToListAsync();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cad_End_Estado> ObterAsync(int Id)
        {
            try
            {
                var obj = await _context.Cad_End_Estado.FirstOrDefaultAsync(f => f.Id == Id);
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cad_End_Estado> ObterAsync(string SiglaUF)
        {
            try
            {
                var obj = await _context.Cad_End_Estado.FirstOrDefaultAsync(f => f.Sigla.Trim().ToUpper() == SiglaUF.Trim().ToUpper());
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cad_End_Estado> CriarAsync(Cad_End_Estado modelo)
        {
            try
            {
                _context.Add(modelo);
                await _context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cad_End_Estado> EditarAsync(Cad_End_Estado modelo)
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

        public async Task<bool> DeletarAsync(Cad_End_Estado modelo)
        {
            try
            {
                _context.Cad_End_Estado.Remove(modelo);
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
            SelectList listagem = new SelectList(_context.Cad_End_Estado, "Id", "Nome");

            if (Id.HasValue)
            {
                listagem = new SelectList(_context.Cad_End_Estado, "Id", "Nome", Id);
            }

            return listagem;
        }
    }
}
