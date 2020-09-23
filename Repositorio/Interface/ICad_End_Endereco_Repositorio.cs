using Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Repositorio
{
    public interface ICad_End_Endereco_Repositorio
    {
        Task<List<Cad_End_Endereco>> ListarAsync();
        Task<Cad_End_Endereco> ObterAsync(int Id);

        Task<Cad_End_Endereco> ObterAsync(string CEP);

        Task<Cad_End_Endereco> ObterPorCodigoIGBEAsync(string CodigoIBGE);

        Task<Cad_End_Endereco> CriarAsync(Cad_End_Endereco modelo);

        Task<Cad_End_Endereco> EditarAsync(Cad_End_Endereco modelo);

        Task<bool> DeletarAsync(Cad_End_Endereco modelo);

        SelectList GerarSelectList(int? Id);
    }
}