using System.ComponentModel;
using System.Linq.Expressions;

namespace Poc.Enums;

public class Messages
{
    public enum LoginEnum
    {
        [Description("Ok")]
        Ok = 1
    }

    public enum CadastroEnum
    {
        [Description("Ok")]
        Ok = 1,

        [Description("Nulo")]
        Nulo = 2
    }

    public static string PrecisaSerPreenchido(string expressao)
    {
        return $"O campo {expressao} precisa ser preenchido.";
    }
}