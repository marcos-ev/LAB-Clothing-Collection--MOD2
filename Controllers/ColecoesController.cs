using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_md2.Models.Enum;
using Project_md2.Models.ViewModels;
using Project_md2.Services.Interfaces;

namespace Project_md2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColecoesController : ControllerBase
    {
        private readonly IColecoesService _service;

        public ColecoesController(IColecoesService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostColecao colecao)
        {
            try
            {
                var result = await _service.CreateAsync(colecao);

                return result switch
                {
                    null => Conflict("A coleção já está cadastrada."),
                    false => BadRequest("Erro ao criar a coleção."),
                    _ => StatusCode((int)HttpStatusCode.Created)
                };
            }
            catch (Exception)
            {
                return BadRequest("Erro ao criar a coleção.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PutColecao colecao)
        {
            try
            {
                var result = await _service.UpdateAsync(colecao);

                return result switch
                {
                    null => NotFound("Coleção não encontrada."),
                    false => BadRequest("Erro ao alterar a coleção."),
                    _ => Ok(colecao)
                };
            }
            catch (Exception)
            {
                return BadRequest("Erro ao alterar a coleção.");
            }
        }

        [HttpPut("{id}/estadosistema")]
        public async Task<IActionResult> UpdateEstadoSistema([FromRoute] int id, [FromBody] EstadoSistema estadoSistema)
        {
            try
            {
                var result = await _service.UpdateEstadoSistemaAsync(id, estadoSistema);

                return result switch
                {
                    null => NotFound("Coleção/Estado do Sistema não encontrado."),
                    false => BadRequest("Erro ao alterar o estado do sistema da coleção."),
                    _ => Ok(estadoSistema)
                };
            }
            catch (Exception)
            {
                return BadRequest("Erro ao alterar o estado do sistema da coleção.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] EstadoSistema? estadoSistema)
        {
            try
            {
                var colecoes = await _service.GetAllAsync(estadoSistema);
                return Ok(colecoes);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao listar as coleções.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var colecao = await _service.GetByIdAsync(id);
                return Ok(colecao);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao obter a coleção.");
            }
        }
    }
}
