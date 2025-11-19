using Poc.Models;

namespace Poc.ViewModels;

public class UsuariosViewModel
{
    public UsuariosViewModel(IEnumerable<UsuarioModel> usuarios)
    {
        Usuarios = usuarios;
    }
    public IEnumerable<UsuarioModel> Usuarios { get; set; }
}