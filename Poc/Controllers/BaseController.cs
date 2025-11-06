using Microsoft.AspNetCore.Mvc;

namespace Poc.Controllers
{
    public class BaseController : Controller
    {
        protected void MensagemModal(string tipo, string mensagem = null)
        {
            // Caso não tenha mensagem manual, usa o ModelState
            if (string.IsNullOrEmpty(mensagem) && ViewData.ModelState.ErrorCount > 0)
            {
                mensagem = string.Join("<br/>",
                    ViewData.ModelState.Values
                    .SelectMany(s => s.Errors.Select(e => e.ErrorMessage))
                    .Distinct()
                );

                // Campos inválidos
                TempData["CamposInvalidos"] = ViewData.ModelState
                    .Where(w => w.Value.Errors.Count > 0)
                    .Select(s => s.Key)
                    .ToList();
            }
            else
            {
                TempData["CamposInvalidos"] = new List<string>();
            }

            TempData["TipoModal"] = tipo;
            TempData["MensagemModal"] = mensagem;
            TempData["ExibirModal"] = "true";
        }

        // protected void MensagemModal(string tipo, string mensagem = null)
        // {
        //     if (string.IsNullOrEmpty(mensagem) && ViewData.ModelState.ErrorCount > 0)
        //     {
        //         mensagem = string.Join("<br/>", ViewData.ModelState.Values
        //             .SelectMany(s => s.Errors.Select(ss => ss.ErrorMessage))
        //             .Distinct());
        //     }

        //     TempData["TipoModal"] = tipo;
        //     TempData["MensagemModal"] = mensagem;
        //     TempData["ExibirModal"] = "true";
        // }

        protected void Erro(string mensagem) => MensagemModal("erro", mensagem);
        protected void Sucesso(string mensagem) => MensagemModal("sucesso", mensagem);
        protected void Alerta(string mensagem = null) => MensagemModal("alerta", mensagem);
    }
}
