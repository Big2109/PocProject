namespace Migrations.Entities;

public class Cliente
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public Guid GuidCliente { get; set; }
}