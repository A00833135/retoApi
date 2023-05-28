using ApiVideojuego.Models;
using ApiVideojuego.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVideojuego.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuariosRepository;

        public LoginController(IUsuarioRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        [HttpGet("{email}, {contrasena}")]
        public async Task<IActionResult> GetUsuarioLogin(string email, string contrasena)
        {
            return Ok(await _usuariosRepository.GetUsuarioLogin(email, contrasena));
        }
    }
}
