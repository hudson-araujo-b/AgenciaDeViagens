using AgenciaDeViagens.Models;
using AgenciaDeViagens.Interfaces;
using MySql.Data.MySqlClient;

namespace AgenciaDeViagens.Repository
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly string _connectionString;

        public UsuarioRepositorio(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Conexao")!;
        }

        public void criarConta(UsuarioModel usuario)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                string senhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.senhaHash);

                var sql = "INSERT INTO usuario (nome,email,senha_hash) VALUES (@nome,@email,@senha)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", usuario.nome);
                cmd.Parameters.AddWithValue("@email", usuario.email);
                cmd.Parameters.AddWithValue("@senha", senhaHash);
                cmd.ExecuteNonQuery();

            }

        }
    }
}
