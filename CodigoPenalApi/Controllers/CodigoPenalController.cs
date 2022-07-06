using CodigoPenalApi.Models;
using CodigoPenalApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodigoPenalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodigoPenalController : ControllerBase
    {
        private ICodigoPenalService _CPService;

        public CodigoPenalController(ICodigoPenalService CPService)
        {
            _CPService = CPService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<CriminalCode>>> 
            GetCriminalCodes()
        {
            try
            {
                var ccs = await _CPService.GetCriminalCodes();
                return Ok(ccs);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter CriminalCodes.");
            }
        }

        [HttpGet("CodigoPenalPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<CriminalCode>>>
            GetCriminalCodesByName([FromQuery] string name)
        {
            try
            {
                var ccs = await _CPService.GetCriminalCodesByName(name);

                if (ccs.Count() == 0)
                {
                    return NotFound($"Não existem códigos penais com o nome: \"{name}\"");
                    
                }
                return Ok(ccs);
            }
            catch
            {
                return BadRequest("Request inválido.");
            }
        }

        [HttpGet("{id:int}", Name = "GetCriminalCodes")]
        public async Task<ActionResult<CriminalCode>> 
            GetCriminalCodes(int id)
        {
            try
            {
                var cc = await _CPService.GetCriminalCodes(id);

                if (cc == null)
                    return NotFound($"Não existe código penal com id: \"{id}\"");

                return Ok(cc);
            }
            catch
            {
                return BadRequest("Request inválido.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> 
            Create(CriminalCode criminalCode)
        {
            try
            {
                await _CPService.CreateCriminalCode(criminalCode);
                return CreatedAtRoute(nameof(GetCriminalCodes), new { id = criminalCode.Id }, criminalCode);
            }
            catch
            {
                return BadRequest("Request inválido.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> 
            Edit(int id, [FromBody] CriminalCode criminalCode)
        {
            try
            {
                if (criminalCode.Id == id)
                {
                    await _CPService.UpdateCriminalCode(criminalCode);
                    return Ok($"Codigo Penal com id: \"{id}\" foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados inconsistentes.");
                }
            }
            catch
            {
                return BadRequest("Request inválido.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> 
            Delete(int id)
        {
            try
            {
                var cc = await _CPService.GetCriminalCodes(id);

                if(cc != null)
                {
                    await _CPService.DeleteCriminalCode(cc);
                    return Ok($"Codigo Penal de id: \"{id}\" foi excluido com sucesso!");
                }
                else
                {
                    return NotFound($"Codigo Penal de id: \"{id}\" não encontrado :(.");
                }
            }
            catch
            {
                return BadRequest("Request inválido.");
            }
        }
    }
}
