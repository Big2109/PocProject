using static Poc.Enums.Messages;

namespace Poc.Models;

public class ValidacaoModel
{
    public bool Sucesso { get; set; }
    public List<string> Mensagem { get; set; }
    public CadastroEnum Cadastro { get; set; }
    public LoginEnum Login { get; set; }
}