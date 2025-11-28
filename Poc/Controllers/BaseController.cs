using Microsoft.AspNetCore.Mvc;

namespace Poc.Controllers;

public class BaseController : Controller
{
    private readonly ILogger _logger;
    public BaseController(ILogger logger)
    {
        _logger = logger;
    }
    protected void MensagemModal(string tipo, string mensagem = null)
    {
        if (string.IsNullOrEmpty(mensagem) && ViewData.ModelState.ErrorCount > 0)
        {
            mensagem = string.Join("<br/>",
                ViewData.ModelState.Values
                .SelectMany(s => s.Errors.Select(e => e.ErrorMessage))
                .Distinct()
            );

            TempData["CamposInvalidos"] = ViewData.ModelState
                .Where(w => w.Value.Errors.Count > 0)
                .Select(s => s.Key)
                .ToList();
        }
        else
        {
            TempData["CamposInvalidos"] = new List<string>();
        }

        TempData["TipoMensagem"] = tipo;
        TempData["Mensagem"] = mensagem;
    }

    protected void ConfirmacaoModal(string mensagem = null)
    {
        TempData["Mensagem"] = mensagem;
    }

    protected void Erro(string mensagem) => MensagemModal("erro", mensagem);
    protected void Sucesso(string mensagem) => MensagemModal("sucesso", mensagem);
    protected void Alerta(string mensagem = null) => MensagemModal("alerta", mensagem);
    public IActionResult Confirmacao(string mensagem)
    {
        ConfirmacaoModal(mensagem);
        return Redirect(Request.Headers["Referer"].ToString());
    }
}
