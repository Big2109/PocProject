namespace Poc.Models;

public class UsuarioModel
{
    public Guid GuidUsuario { get; set; }
    public string Nome { get; set; }
    public string NomeUsuario { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public DateTime HorarioAcesso { get; set; }
}