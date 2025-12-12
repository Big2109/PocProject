using System.ComponentModel.DataAnnotations;

namespace Migrations.Entities;

public class Acesso
{
    [Key]
    public Guid GuidAcesso { get; set; }
    public Guid GuidUsuario { get; set; }
    public DateTime HorarioAcesso { get; set; }
    public Usuario Usuario { get; set; }
}