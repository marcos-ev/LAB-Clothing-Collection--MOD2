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
    public class ModelosController : ControllerBase
    {
        private readonly IModelosService _service;

        public ModelosController(IModelosService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostModelo modelo)
        {
            try
            {
                var result = await _service.CreateAsync(modelo);

                return result switch
                {
                    null => Conflict("O modelo já está cadastrado."),
                    false => BadRequest("Erro ao criar o modelo."),
                    _ => StatusCode((int)HttpStatusCode.Created)
                };
            }
            catch (Exception)
            {
                return BadRequest("Erro ao criar o modelo.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PutModelo modelo)
        {
            try
            {
                var result = await _service.UpdateAsync(modelo);

                return result switch
                {
                    null => NotFound("Modelo não encontrado."),
                    false => BadRequest("Erro ao alterar o modelo."),
                    _ => Ok(modelo)
                };
            }
            catch (Exception)
            {
                return BadRequest("Erro ao alterar o modelo.");
            }
        }

        [HttpPut("{id}/layout")]
        public async Task<IActionResult> UpdateLayout([FromRoute] int id, Layout layout)
        {
            try
            {
                var result = await _service.UpdateLayoutAsync(id, layout);

                return result switch
                {
                    null => NotFound("Modelo/Layout não encontrado."),
                    false => BadRequest("Erro ao alterar o layout do modelo."),
                    _ => Ok(layout)
                };
            }
            catch (Exception)
            {
                return BadRequest("Erro ao alterar o layout do modelo.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Layout? layout)
        {
            try
            {
                var modelos = await _service.GetAllAsync(layout);
                return Ok(modelos);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao listar os modelos.");
            }
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var modelo = await _service.GetByIdAsync(id);

                return modelo != null ? Ok(modelo) : NotFound("Modelo não encontrado.");
            }
            catch (Exception)
            {
                return BadRequest("Erro ao obter o modelo.");
            }
        }
    }
}
