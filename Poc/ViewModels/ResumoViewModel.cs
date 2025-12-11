using Poc.Models;
using static Poc.Models.ResumoModel;

namespace Poc.ViewModels;

public class ResumoViewModel
{
    public ResumoViewModel(
        IEnumerable<CriadosPorDia> usuarios,
        IEnumerable<CriadosPorDia> produtos)
    {
        Usuarios = usuarios;
        Produtos = produtos;
    }
    public IEnumerable<CriadosPorDia> Usuarios { get; set; }
    public IEnumerable<CriadosPorDia> Produtos { get; set; }
}