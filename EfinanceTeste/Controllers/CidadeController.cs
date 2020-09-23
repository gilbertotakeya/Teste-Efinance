using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositorio;

namespace EfinanceTeste.Controllers
{
    public class CidadeController : Controller
    {
        private readonly ICad_End_Cidade_Repositorio _Cidade_Repositorio;
        private readonly ICad_End_Estado_Repositorio _Estado_Repositorio;

        public CidadeController(ICad_End_Cidade_Repositorio Cidade_Repositorio,
            ICad_End_Estado_Repositorio Estado_Repositorio)
        {
            _Estado_Repositorio = Estado_Repositorio;
            _Cidade_Repositorio = Cidade_Repositorio;
        }

        public async Task<IActionResult> Index(string PesquisaCidade = "")
        {

            if (!string.IsNullOrEmpty(PesquisaCidade))
            {
                var lista = await _Cidade_Repositorio.ListarCidadeAsync(PesquisaCidade);
                return View(lista);
            }
            else
            {
                var lista = await _Cidade_Repositorio.ListarAsync();
                return View(lista);
            }
        }

        private async Task carregarDadosView()
        {
            var lista = await _Estado_Repositorio.ListarAsync();
            IEnumerable<SelectListItem> estadoLista = new SelectList(lista.AsEnumerable(), "Id", "Nome");

            ViewData["EstadoId"] = estadoLista;//_Estado_Repositorio.GerarSelectList(null);
        }

        public async Task<IActionResult> Create()
        {
            await carregarDadosView();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cad_End_Cidade model)
        {
            try
            {
                ModelState.Remove("Id");
                ModelState.Remove("DataInclusao");

                if (ModelState.IsValid)
                {
                    var saved = await _Cidade_Repositorio.CriarAsync(model);
                    if (saved != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    return BadRequest();
                }

                TempData["msgDanger"] = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                await carregarDadosView();
                return View(model);
            }
            catch(Exception ex)
            {
                await carregarDadosView();
                TempData["msgDanger"] = ex.Message;
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _Cidade_Repositorio.ObterAsync(id);
            await carregarDadosView();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cad_End_Cidade model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var saved = await _Cidade_Repositorio.EditarAsync(model);
                    if (saved != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    return BadRequest();
                }

                TempData["msgDanger"] = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                await carregarDadosView();
                //ViewData["Endereco"] = _Endereco_Repositorio.GerarSelectList(model.IdEndereco);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["msgDanger"] = ex.Message;
                await carregarDadosView();
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _Cidade_Repositorio.ObterAsync(id);
            return View(model);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var model = await _Cidade_Repositorio.ObterAsync(id);

                var salvo = await _Cidade_Repositorio.DeletarAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
