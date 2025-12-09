namespace Poc.ViewModels;

public class ProdutosViewModel
{
    public ProdutosViewModel(IEnumerable<ProdutoModel> produtos)
    {
        Produtos = produtos;
    }
    public IEnumerable<ProdutoModel> Produtos { get; set; }
}