using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Condominio.Services;
using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Familia.Services;
using ConstructoIT.Hotel.Accor.Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace ConstructoIT.Hotel.Accor.Site.Controllers
{
    public class FamiliaController : Controller
    {
        private readonly IFamiliaService _familiaService;
        private readonly ICondominioService _condominioService;
        private readonly ILogger<FamiliaController> _logger;

        public FamiliaController(IFamiliaService familiaService, ICondominioService condominioService, ILogger<FamiliaController> logger)
        {
            _familiaService = familiaService;
            _condominioService = condominioService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Condominios = await ListarCondominioAsync();
            return View();
        }

        public async Task<IActionResult> Listar()
        {
            return Json(await _familiaService.ListarAsync());
        }

        public async Task<IActionResult> ListarFamilia()
        {
            return Json(await _familiaService.ListarFamiliaAsync());
        }

        public async Task<IActionResult> ObterFamilia(int id)
        {
            return Json(await _familiaService.ObterFamiliaAsync(id));
        }

        public async Task<IActionResult> ObterId(int id)
        {
            return Json(await _familiaService.ObterAsync(id));
        }

        public async Task Cadastrar([FromBody] FamiliaViewModel familia)
        {
            await _familiaService.CadastrarAsync(familia);
        }

        [HttpPut]
        public async Task Atualizar([FromBody] FamiliaViewModel familia)
        {
            await _familiaService.AtualizarAsync(familia);
        }

        public async Task Remover(int id)
        {
            await _familiaService.ExcluirAsync(id);
        }

        private async Task<List<SelectListItem>> ListarCondominioAsync()
        {
            var condominios = await _condominioService.ListarAsync();

            if (condominios.Any())
            {
                return condominios.Select(x => new SelectListItem { Text = x.Nome, Value = x.Id.ToString() }).ToList();
            }

            return new List<SelectListItem> { new SelectListItem { Text = "Selecione" } };
        }
    }
}