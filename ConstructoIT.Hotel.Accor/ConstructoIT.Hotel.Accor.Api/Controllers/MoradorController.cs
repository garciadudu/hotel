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
    public class MoradorController : ControllerBase
    {
        private readonly IApplicationServiceMorador _applicationServiceMorador;
        private readonly ILogger<MoradorController> _logger;

        public MoradorController(IApplicationServiceMorador applicationServiceMorador, ILogger<MoradorController> logger)
        {
            _applicationServiceMorador = applicationServiceMorador ?? throw new ArgumentNullException(nameof(applicationServiceMorador));
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<MoradorDTO>> Get()
        {
            return await _applicationServiceMorador.GetAllAsync();
        }

        [HttpGet]
        [Route("GetAllMorador")]
        public async Task<IEnumerable<MoradorDTO>> GetAllMorador()
        {
            return await _applicationServiceMorador.GetAllMoradorAsync();
        }


        [HttpGet]
        [Route("ObterMorador/{id}")]
        public async Task<MoradorDTO> ObterMorador(int id)
        {
            return await _applicationServiceMorador.ObterMoradorAsync(id);
        }

        [HttpGet("{id}")]
        public async Task<MoradorDTO> Get(int id)
        {
            return await _applicationServiceMorador.GetByIdAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(MoradorDTO), StatusCodes.Status200OK)]
        public IActionResult Post([FromBody] MoradorDTO Morador)
        {
            try
             {
                if (Morador == null || (string.IsNullOrEmpty(Morador.Nome)))
                    return NotFound();

                _applicationServiceMorador.Add(Morador);
                return Ok("Morador cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Put(int id, [FromBody] MoradorDTO Morador)
        {
            try
            {
                if (Morador == null)
                    return NotFound();

                _applicationServiceMorador.Update(Morador);

                return Ok("Morador atualizado com sucesso!");
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
                var familia = await _applicationServiceMorador.GetByIdAsync(id);
                if (familia is null)
                    return NotFound();

                familia = new MoradorDTO
                {
                    Id = id
                };

                _applicationServiceMorador.Remove(familia);
                return Ok("Morador removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}