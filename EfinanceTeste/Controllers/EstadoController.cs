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
    public class EstadoController : Controller
    {
        private readonly ICad_End_Estado_Repositorio _Estado_Repositorio;

        public EstadoController(ICad_End_Estado_Repositorio Estado_Repositorio)
        {
            _Estado_Repositorio = Estado_Repositorio;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _Estado_Repositorio.ListarAsync();
            return View(lista);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cad_End_Estado model)
        {
            try
            {
                ModelState.Remove("Id");
                ModelState.Remove("DataInclusao");

                if (ModelState.IsValid)
                {
                    var saved = await _Estado_Repositorio.CriarAsync(model);
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
            catch(Exception ex)
            {
                TempData["msgDanger"] = ex.Message;
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _Estado_Repositorio.ObterAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cad_End_Estado model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var saved = await _Estado_Repositorio.EditarAsync(model);
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

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _Estado_Repositorio.ObterAsync(id);
            return View(model);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var model = await _Estado_Repositorio.ObterAsync(id);

                var salvo = await _Estado_Repositorio.DeletarAsync(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
