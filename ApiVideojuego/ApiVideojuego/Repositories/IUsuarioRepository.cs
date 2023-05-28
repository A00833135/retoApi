using ApiVideojuego.Models;

namespace ApiVideojuego.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<Usuario> GetDetails(int idUsuario);
        Task<Usuario> GetUsuarioLogin(string email, string contrasena);
        Task<bool> InsertUsuario(Usuario usuario);
    }
}
