using System.ComponentModel.DataAnnotations;

namespace AgenciaDeViagens.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string email { get; set; } = string.Empty;
        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string senhaHash { get; set; } = string.Empty;
    }
}
