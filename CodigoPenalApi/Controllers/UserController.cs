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
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsers();
                return Ok(users);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Usuários.");
            }
        }

        [HttpGet("UsuariosPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<User>>> 
            GetUsersByName([FromQuery] string name)
        {
            try
            {
                var users = await _userService.GetUsersByName(name);

                if (users.Count() == 0)
                    return NotFound($"Não existem usuários com o nome: \"{name}\"");

                return Ok(users);
            }
            catch
            {
                return BadRequest("Request inválido.");
            }
        }

        [HttpGet("{id:int}", Name = "GetUsers")]
        public async Task<ActionResult<User>> GetUsers(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);

                if (user == null)
                    return NotFound($"Não existe usuário com id: \"{id}\"");

                return Ok(user);
            }
            catch
            {
                return BadRequest("Request inválido.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            try
            {
                await _userService.CreateUser(user);
                return CreatedAtRoute(nameof(GetUsers), new { id = user.Id }, user);
            }
            catch
            {
                return BadRequest("Request inválido.");
            }
        }
    }
}
