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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _service;

        public UsuariosController(IUsuariosService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostUsuario usuario)
        {
            try
            {
                var result = await _service.CreateAsync(usuario);

                return result switch
                {
                    null => Conflict("O usuário já está cadastrado."),
                    false => BadRequest("Erro ao criar o usuário."),
                    _ => StatusCode((int)HttpStatusCode.Created)
                };
            }
            catch (Exception)
            {
                return BadRequest("Erro ao criar o usuário.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] PutUsuario usuario)
        {
            try
            {
                var result = await _service.UpdateAsync(usuario);

                return result switch
                {
                    null => NotFound("Usuário não encontrado."),
                    false => BadRequest("Erro ao alterar o usuário."),
                    _ => Ok(usuario)
                };
            }
            catch (Exception)
            {
                return BadRequest("Erro ao alterar o usuário.");
            }
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus([FromRoute] int id, Status status)
        {
            try
            {
                var result = await _service.UpdateStatusAsync(id, status);

                return result switch
                {
                    null => NotFound("Usuário/Status não encontrado."),
                    false => BadRequest("Erro ao alterar o status do usuário."),
                    _ => Ok(status)
                };
            }
            catch (Exception)
            {
                return BadRequest("Erro ao alterar o status do usuário.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Status? status)
        {
            try
            {
                var usuarios = await _service.GetAllAsync(status);
                return Ok(usuarios);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao listar os usuários.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var usuario = await _service.GetByIdAsync(id);

                return usuario != null ? Ok(usuario) : NotFound("Usuário não encontrado.");
            }
            catch (Exception)
            {
                return BadRequest("Erro ao obter o usuário.");
            }
        }
    }
}
