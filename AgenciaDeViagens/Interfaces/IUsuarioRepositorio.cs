using AgenciaDeViagens.Models;

namespace AgenciaDeViagens.Interfaces
{
    public interface IUsuarioRepositorio
    {
        public void criarConta(UsuarioModel usuario);
        public UsuarioModel? validarLogin(string email, string senha);
    }
}
