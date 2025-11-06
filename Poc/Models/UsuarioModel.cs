using System.ComponentModel.DataAnnotations;

namespace Poc.Models;

public class UsuarioModel
{
    public Guid GuidUsuario { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Nome de usuário é obrigatório.")]
    public string NomeUsuario { get; set; }

    [Required(ErrorMessage = "E-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Senha é obrigatória.")]
    public string Senha { get; set; }
    public DateTime HorarioAcesso { get; set; }
}