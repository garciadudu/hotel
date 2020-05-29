using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Familia.Services;
using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Morador.Services;
using ConstructoIT.Hotel.Accor.Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace ConstructoIT.Hotel.Accor.Site.Controllers
{
    public class MoradorController : Controller
    {
        private readonly IMoradorService _moradorService;
        private readonly IFamiliaService _familiaService;
        private readonly ILogger<MoradorController> _logger;

        public MoradorController(IMoradorService moradorService, IFamiliaService familiaService, ILogger<MoradorController> logger)
        {
            _moradorService = moradorService;
            _familiaService = familiaService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Familias = await ListarFamiliaAsync();

            return View();
        }

        public async Task<IActionResult> Listar()
        {
            return Json(await _moradorService.ListarAsync());
        }

        public async Task<IActionResult> ListarMorador()
        {
            return Json(await _moradorService.ListarMoradorAsync());
        }


        public async Task<IActionResult> ObterMorador(int id)
        {
            return Json(await _moradorService.ObterMoradorAsync(id));
        }


        public async Task<IActionResult> ObterId(int id)
        {
            return Json(await _moradorService.ObterAsync(id));
        }


        public async Task Cadastrar([FromBody] MoradorViewModel morador)
        {
            await _moradorService.CadastrarAsync(morador);
        }

        [HttpPut]
        public async Task Atualizar([FromBody] MoradorViewModel morador)
        {
            await _moradorService.AtualizarAsync(morador);
        }

        public async Task Remover(int id)
        {
            await _moradorService.ExcluirAsync(id);
        }

        private async Task<List<SelectListItem>> ListarFamiliaAsync()
        {
            var familias = await _familiaService.ListarAsync();

            if (familias.Any())
            {
                return familias.Select(x => new SelectListItem { Text = x.Nome, Value = x.Id.ToString() }).ToList();
            }

            return new List<SelectListItem> { new SelectListItem { Text = "Selecione" } };
        }
    }
}