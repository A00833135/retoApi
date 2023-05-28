using ApiVideojuego.Models;
using ApiVideojuego.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVideojuego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUsuarioRepository _usuariosRepository;

        public RegisterController(IUsuarioRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            return Ok(await _usuariosRepository.GetAllUsuarios());
        }

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> GetUserDetails(int idUsuario)
        {
            return Ok(await _usuariosRepository.GetDetails(idUsuario));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody]Usuario usuario)
        {
            if(usuario == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var created = await _usuariosRepository.InsertUsuario(usuario);

            return Created("created", created);
        }
    }
}
