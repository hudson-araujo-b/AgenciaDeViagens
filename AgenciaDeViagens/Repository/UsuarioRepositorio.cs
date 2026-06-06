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

                var sql = "INSERT INTO usuario (nome,email,senha_hash,nivel_acesso) VALUES (@nome,@email,@senha,@nivel)";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", usuario.nome);
                cmd.Parameters.AddWithValue("@email", usuario.email);
                cmd.Parameters.AddWithValue("@senha", senhaHash);
                cmd.Parameters.AddWithValue("@nivel", usuario.nivelAcesso);
                cmd.ExecuteNonQuery();

            }

        }
        public UsuarioModel? validarLogin(string email, string senha)
        {
            using var conn = new MySqlConnection(_connectionString);

            conn.Open();

            var sql = "SELECT * FROM usuario WHERE email= @email";

            var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email", email);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string senhaBanco = reader["senha_hash"].ToString()!;

                if (BCrypt.Net.BCrypt.Verify(senha, senhaBanco))
                {
                    return new UsuarioModel
                    {
                        id = Convert.ToInt32(reader["id"]),
                        nome = reader["nome"].ToString()!,
                        email = reader["email"].ToString()!,
                        nivelAcesso = reader["nivelAcesso"].ToString()!
                    };
                }

            }

            return null;
        }
    }
}

