using AgenciaDeViagens.Models;

namespace AgenciaDeViagens.Interfaces
{
    public interface IUsuarioRepositorio
    {
        public void criarConta(UsuarioModel usuario);
    }
}
