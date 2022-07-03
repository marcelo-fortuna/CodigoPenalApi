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
    [Produces("applications/json")]
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
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter users.");
            }
        }
    }
}
