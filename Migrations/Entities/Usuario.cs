namespace Migrations.Entities;

public class Usuario
{
    public Guid GuidUsuario { get; set; }
    public string Nome { get; set; }
    public string NomeUsuario { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime HorarioAcesso { get; set; }
    public bool Ativo { get; set; }
    public Acesso Acesso { get; set; }

}