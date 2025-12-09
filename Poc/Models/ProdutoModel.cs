public class ProdutoModel
{
    public Guid GuidUsuario { get; set; }
    public Guid GuidProduto { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Icone { get; set; }
    public string CorHex { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }
}