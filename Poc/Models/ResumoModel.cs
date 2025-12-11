namespace Poc.Models;

public class ResumoModel
{
    public ResumoModel(
        IEnumerable<UsuarioModel> usuarios,
        IEnumerable<ProdutoModel> produtos)
    {
        Usuarios = usuarios;
        Produtos = produtos;
    }
    public IEnumerable<UsuarioModel> Usuarios { get; set; }
    public IEnumerable<ProdutoModel> Produtos { get; set; }

    public class CriadosPorDia
    {
        public int Quantidade { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}