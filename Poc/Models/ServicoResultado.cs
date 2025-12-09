namespace Poc.Models;

public class ServicoResultado<T>
{
    protected Exception _excecao;
    protected ICollection<string> _erros;
    protected bool _sucesso;
    protected T _valor;
    protected string _successMessage;

    public ServicoResultado() => _erros = new HashSet<string>();

    protected void HandleException(Exception value)
    {
        _excecao = value;
        if (_excecao != null)
        {
            _erros.Add(_excecao.ToString());
            _sucesso = false;
        }
    }

    protected void HandleValor(T value)
    {
        _valor = value;
        _sucesso = true;
    }

    public Exception Excecao
    {
        get => _excecao;
        protected set => HandleException(value);
    }

    public T Valor
    {
        get => _valor;
        protected set => HandleValor(value);
    }

    public string SuccessMessage
    {
        get => _successMessage;
        protected set => _successMessage = value;
    }

    public Guid ErrorCode { get; set; }
    public string OrigemExcecao { get; set; }
    public int Auxiliar { get; set; }

    public string FirstError() => _erros?.FirstOrDefault();

    public IEnumerable<string> Erros { get => _erros; }
    public bool Sucesso { get => _sucesso; }
    public bool EhFatal => _excecao != null;
    public static ServicoResultado<T> Ok(T valor) => new ServicoResultado<T> { Valor = valor };
    public static ServicoResultado<T> Ok(T valor, string message) => new ServicoResultado<T> { Valor = valor, SuccessMessage = message };
    public static ServicoResultado<T> Falha(string mensagem) => new ServicoResultado<T> { _erros = new HashSet<string> { mensagem } };
    public static ServicoResultado<T> Falha(string mensagem, T valor) => new ServicoResultado<T> { _erros = new HashSet<string> { mensagem }, _valor = valor };
    public static ServicoResultado<T> Falha(IEnumerable<string> erros) => new ServicoResultado<T> { _erros = erros.ToList() };
    public static ServicoResultado<T> Falha(IEnumerable<string> erros, T valor) => new ServicoResultado<T> { _erros = erros.ToList(), _valor = valor };
    public static ServicoResultado<T> Fatal(Exception excecao) => new ServicoResultado<T> { Excecao = excecao, ErrorCode = Guid.NewGuid() };
    public static ServicoResultado<T> Fatal(Exception excecao, string origem) => new ServicoResultado<T> { Excecao = excecao, OrigemExcecao = origem };
    public static ServicoResultado<T> Fatal(string error, Guid errorCode) => new ServicoResultado<T> { _erros = new HashSet<string> { error }, ErrorCode = errorCode };
}

public class ServicoResultado : ServicoResultado<object>
{
    public new static ServicoResultado<object> Ok(object valor) => new ServicoResultado { Valor = null };
    public new static ServicoResultado<object> Ok(object valor, string message) => new ServicoResultado { Valor = null, SuccessMessage = message };
    public static ServicoResultado Ok() => new ServicoResultado { Valor = null };
    public static ServicoResultado Ok(string message) => new ServicoResultado { Valor = null, SuccessMessage = message };
    public new static ServicoResultado Falha(string mensagem) => new ServicoResultado { _erros = new HashSet<string> { mensagem } };
    public new static ServicoResultado Falha(IEnumerable<string> erros) => new ServicoResultado { _erros = erros.ToList() };
    public new static ServicoResultado Fatal(Exception excecao) => new ServicoResultado { Excecao = excecao, ErrorCode = Guid.NewGuid() };
    public new static ServicoResultado Fatal(Exception excecao, string origem) => new ServicoResultado { Excecao = excecao, OrigemExcecao = origem };
    public new static ServicoResultado Fatal(string error, Guid errorCode) => new ServicoResultado { _erros = new HashSet<string> { error }, ErrorCode = errorCode };

}