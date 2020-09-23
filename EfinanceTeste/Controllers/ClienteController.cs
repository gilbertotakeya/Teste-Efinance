using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Repositorio;

namespace EfinanceTeste.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ICli_ClienteRepositorio _ClienteRepositorio;
        private readonly ICad_End_Endereco_Repositorio _Endereco_Repositorio;
        private readonly ICad_End_Estado_Repositorio _Estado_Repositorio;
        private readonly ICad_End_Cidade_Repositorio _Cidade_Repositorio;

        public ClienteController(ICli_ClienteRepositorio ClienteRepositorio,
            ICad_End_Endereco_Repositorio Endereco_Repositorio,
            ICad_End_Estado_Repositorio Estado_Repositorio,
            ICad_End_Cidade_Repositorio Cidade_Repositorio)
        {
            _ClienteRepositorio = ClienteRepositorio;
            _Endereco_Repositorio = Endereco_Repositorio;
            _Estado_Repositorio = Estado_Repositorio;
            _Cidade_Repositorio = Cidade_Repositorio;
        }

        // GET: ClienteController
        public async Task<IActionResult> Index()
        {
            var lista = await _ClienteRepositorio.ListarProcAsync();//.ListarAsync();
            return View(lista);
        }


        // GET: ClienteController/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["Endereco"] = _Endereco_Repositorio.GerarSelectList(null);
            return View();
        }

        private async Task Salvar(Cli_Cliente model)
        {
            //Pega o Estado e atualiza os objetos
            var estado = await _Estado_Repositorio.ObterAsync(model.Estado.Sigla);
            if (estado == null)
                throw new SystemException("Falha ao buscar o estado");

            model.Estado = model.Endereco.Estado = estado;
            model.EstadoId = model.Endereco.EstadoId = estado.Id;

            //Pega a Cidade e atualiza os objetos
            var cidade = await _Cidade_Repositorio.ObterAsync(model.Endereco.CodigoIBGE);
            if (cidade == null)
                throw new SystemException("Falha ao buscar a cidade");

            model.Cidade = model.Endereco.Cidade = cidade;
            model.CidadeId = model.Endereco.Cidade.Id = model.Endereco.CidadeId = cidade.Id;

            //Valida se tem o endereço cadastrado, se não tiver cadastra.
            var temEndereco = await _Endereco_Repositorio.ObterAsync(model.Endereco.CEP);
            if (temEndereco != null)
                model.Endereco = temEndereco;
            else
            {
                var EnderecoIncluir = await _Endereco_Repositorio.CriarAsync(model.Endereco);

                var retNovoEndereco = await _Endereco_Repositorio.ObterAsync(model.Endereco.CEP);
                if (retNovoEndereco != null)
                {
                    model.Endereco = retNovoEndereco;
                }
                else
                    throw new SystemException("Falha ao cadastrar endereço!");
            }
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cli_Cliente model)
        {
            try
            {
                ModelState.Remove("Id");
                ModelState.Remove("EnderecoId");
                ModelState.Remove("DataInclusao");
                ModelState.Remove("CidadeId");
                ModelState.Remove("EstadoId");
                ModelState.Remove("Estado.Id");
                ModelState.Remove("Endereco.Id");
                ModelState.Remove("Endereco.CidadeId");
                ModelState.Remove("Endereco.EstadoId");
                ModelState.Remove("Endereco.Cidade.Id");
                ModelState.Remove("Endereco.EstadoId");

                if (ModelState.IsValid)
                {
                    await Salvar(model);

                    var saved = await _ClienteRepositorio.CriarAsync(model);
                    if (saved != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    return BadRequest();
                }

                TempData["msgDanger"] = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                //ViewData["Endereco"] = _Endereco_Repositorio.GerarSelectList(model.IdEndereco);
                return View(model);
            }
            catch(Exception)
            {
                TempData["msgDanger"] = ex.Message;
                return View(model);
            }
        }

        // GET: ClienteController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _ClienteRepositorio.ObterAsync(id);

            return View(model);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cli_Cliente model)
        {
            try
            {
                ModelState.Remove("Id");
                ModelState.Remove("EnderecoId");
                ModelState.Remove("DataInclusao");
                ModelState.Remove("CidadeId");
                ModelState.Remove("EstadoId");
                ModelState.Remove("Estado.Id");
                ModelState.Remove("Endereco.Id");
                ModelState.Remove("Endereco.CidadeId");
                ModelState.Remove("Endereco.EstadoId");
                ModelState.Remove("Endereco.Cidade.Id");
                ModelState.Remove("Endereco.EstadoId");

                if (ModelState.IsValid)
                {
                    await Salvar(model);

                    var saved = await _ClienteRepositorio.EditarAsync(model);
                    if (saved != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    return BadRequest();
                }

                TempData["msgDanger"] = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                //ViewData["Endereco"] = _Endereco_Repositorio.GerarSelectList(model.IdEndereco);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["msgDanger"] = ex.Message;
                return View(model);
            }
        }

        // GET: ClienteController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cli = await _ClienteRepositorio.ObterAsync(id);
            return View(cli);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var cli = await _ClienteRepositorio.ObterAsync(id);

                var salvo = await _ClienteRepositorio.DeletarAsync(cli);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
