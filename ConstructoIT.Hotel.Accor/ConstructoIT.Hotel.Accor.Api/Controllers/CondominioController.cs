using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructoIT.Hotel.Accor.Aplicacao.Interfaces;
using ConstructoIT.Hotel.Accor.AplicaoDTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConstructoIT.Hotel.Accor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominioController : ControllerBase
    {
        private readonly IApplicationServiceCondominio _applicationServiceCondominio;
        private readonly ILogger<CondominioController> _logger;

        public CondominioController(IApplicationServiceCondominio applicationServiceCondominio,  ILogger<CondominioController> logger)
        {
            _applicationServiceCondominio = applicationServiceCondominio ?? throw new ArgumentNullException(nameof(applicationServiceCondominio));
            _logger = logger;
        }

        [HttpGet] 
        public async Task<IEnumerable<CondominioDTO>> Get()
        {
            return await _applicationServiceCondominio.GetAllAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<CondominioDTO> Get(int id)
        {
            return await _applicationServiceCondominio.GetByIdAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CondominioDTO), StatusCodes.Status200OK)] 
        public IActionResult Post([FromBody] CondominioDTO Condominio)
        {
            try
            {
                if (Condominio == null || (string.IsNullOrEmpty(Condominio.Nome)) || string.IsNullOrEmpty(Condominio.Bairro))
                    return NotFound();

                _applicationServiceCondominio.Add(Condominio);
                return Ok("Condominio cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Put(int id, [FromBody] CondominioDTO Condominio)
        {
            try
            {
                if (Condominio == null)
                    return NotFound();

                Condominio.Id = id;

                _applicationServiceCondominio.Update(Condominio);

                return Ok("Condominio atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete()]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var condominio = await _applicationServiceCondominio.GetByIdAsync(id);
                if (condominio is null)
                    return NotFound();


                condominio = new CondominioDTO
                {
                    Id = id
                };

                _applicationServiceCondominio.Remove(condominio);
                return Ok("Condominio removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}