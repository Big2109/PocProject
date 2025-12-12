namespace Poc.Enums;

public class Messages
{

    public static class Usuario
    {
        public static string RegistradoComSucesso = "";
        public static string SenhaOuUsuarioincorreto = "Senha ou usuário incorreto(s).";
        public static string UsuarioInativo = "Usuário inativo.";
        public static string NomeUsuarioJaEmUso = "Nome de usuário já em uso.";
    }
    public static class Acesso
    {
        public static string ErroObter = "Erro ao obter acesso";
    }
    public static string PrecisaSerPreenchido(string expressao)
    {
        return $"O campo {expressao} não pode ser vazio!";
    }
}