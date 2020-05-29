using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Condominio.Services;
using ConstructoIT.Hotel.Accor.Site.Infraestrutura.Services;
using ConstructoIT.Hotel.Accor.Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConstructoIT.Hotel.Accor.Site.Controllers
{
    public class CondominioController : Controller
    {
        private readonly ICondominioService _condominioService;
        private readonly ILogger<CondominioController> _logger;

        public CondominioController(ICondominioService condominioService, ILogger<CondominioController> logger)
        {
            _condominioService = condominioService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listar()
        {
            return Json(await _condominioService.ListarAsync());
        }

        public async Task<IActionResult> ObterId(int id)
        {
            return Json(await _condominioService.ObterAsync(id));
        }


        public async Task Cadastrar([FromBody] CondominioViewModel condominio)
        {
            await _condominioService.CadastrarAsync(condominio);
        }

        [HttpPut]
        public async Task Atualizar([FromBody] CondominioViewModel condominio)
        {
            await _condominioService.AtualizarAsync(condominio);
        }

        public async Task Remover(int id)
        {
            await _condominioService.ExcluirAsync(id);
        }

    }
}