using ApiVideojuego.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiVideojuego.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MySqlConfiguration _connectionString;

        public UsuarioRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            var db = dbConnection();
            var sql = @"SELECT idUsuario, nombre, email, contrasena FROM Usuario";

            return await db.QueryAsync<Usuario>(sql, new {});
        }

        public async Task<Usuario> GetDetails(int idUsuario)
        {
            var db = dbConnection();
            var sql = @"SELECT idUsuario, nombre, email, contrasena FROM Usuario WHERE idUsuario = @IdUsuario";

            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { IdUsuario = idUsuario});
        }

        public async Task<Usuario> GetUsuarioLogin(string email, string contrasena)
        {
            var db = dbConnection();
            var sql = @"SELECT idUsuario, nombre, email, contrasena FROM Usuario WHERE email = @Email AND contrasena = @Contrasena";

            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Email = email, Contrasena = contrasena });
        }

        public async Task<bool> InsertUsuario(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO Usuario(nombre, email, contrasena) VALUES (@Nombre, @Email, @Contrasena)";

            var result = await db.ExecuteAsync(sql, new {  usuario.Nombre, usuario.Email, usuario.Contrasena});

            return result > 0;
        }
    }
}
