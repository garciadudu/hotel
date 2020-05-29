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
    public class FamiliaController : ControllerBase
    {
        private readonly IApplicationServiceFamilia _applicationServiceFamilia;
        private readonly ILogger<FamiliaController> _logger;

        public FamiliaController(IApplicationServiceFamilia applicationServiceFamilia, ILogger<FamiliaController> logger)
        {
            _applicationServiceFamilia = applicationServiceFamilia ?? throw new ArgumentNullException(nameof(applicationServiceFamilia));
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<FamiliaDTO>> Get()
        {
            return await _applicationServiceFamilia.GetAllAsync();
        }

        [HttpGet]
        [Route("GetAllFamilia")]
        public async Task<IEnumerable<FamiliaDTO>> GetAllFamilia()
        {
            return await _applicationServiceFamilia.GetAllFamiliaAsync();
        }


        [HttpGet]
        [Route("ObterFamilia/{id}")]
        public async Task<FamiliaDTO> ObterFamilia(int id)
        {
            return await _applicationServiceFamilia.ObterFamiliaAsync(id);
        }


        [HttpGet("{id}")]
        public async Task<FamiliaDTO> Get(int id)
        {
            return await _applicationServiceFamilia.GetByIdAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(FamiliaDTO), StatusCodes.Status200OK)]
        public IActionResult Post([FromBody] FamiliaDTO Familia)
        {
            try
            {
                if (Familia == null || (string.IsNullOrEmpty(Familia.Nome)))
                    return NotFound();

                _applicationServiceFamilia.Add(Familia);
                return Ok("Familia cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult PutPut(int id, [FromBody] FamiliaDTO Familia)
        {
            try
            {
                if (Familia == null)
                    return NotFound();

                _applicationServiceFamilia.Update(Familia);

                return Ok("Familia atualizada com sucesso!");
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
                var familia = await _applicationServiceFamilia.GetByIdAsync(id);
                if (familia is null)
                    return NotFound();

                var familiaNew = new FamiliaDTO{
                    Id = id
                };

                _applicationServiceFamilia.Remove(familiaNew);
                return Ok("Familia removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}