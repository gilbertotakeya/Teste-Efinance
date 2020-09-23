using Classes;
using Classes.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Repositorio
{
    public interface ICli_ClienteRepositorio
    {
        Task<List<Cli_Cliente>> ListarAsync();
        Task<List<ListagemClienteViewModel>> ListarProcAsync();

        Task<Cli_Cliente> ObterAsync(int Id);

        Task<Cli_Cliente> CriarAsync(Cli_Cliente modelo);

        Task<Cli_Cliente> EditarAsync(Cli_Cliente modelo);

        Task<bool> DeletarAsync(Cli_Cliente modelo);

        SelectList GerarSelectList(int? Id);
    }
}
