using Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Repositorio
{
    public interface ICad_End_Cidade_Repositorio
    {
        Task<List<Cad_End_Cidade>> ListarAsync();
        
        Task<List<Cad_End_Cidade>> ListarCidadeAsync(string pesquisaCidade);

        Task<Cad_End_Cidade> ObterAsync(int Id);

        Task<Cad_End_Cidade> ObterAsync(string CodigoIBGE);

        Task<Cad_End_Cidade> CriarAsync(Cad_End_Cidade modelo);

        Task<Cad_End_Cidade> EditarAsync(Cad_End_Cidade modelo);

        Task<bool> DeletarAsync(Cad_End_Cidade modelo);

        //SelectListItem GerarSelectList(int? Id);
        List<SelectListItem> GerarSelectList(int? Id);
    }
}
