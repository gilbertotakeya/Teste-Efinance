using Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Repositorio
{
    public interface ICad_End_Estado_Repositorio
    {

        Task<List<Cad_End_Estado>> ListarAsync();

        Task<Cad_End_Estado> ObterAsync(int Id);

        Task<Cad_End_Estado> ObterAsync(string SiglaUF);

        Task<Cad_End_Estado> CriarAsync(Cad_End_Estado modelo);

        Task<Cad_End_Estado> EditarAsync(Cad_End_Estado modelo);

        Task<bool> DeletarAsync(Cad_End_Estado modelo);

        SelectList GerarSelectList(int? Id);
    }
}
