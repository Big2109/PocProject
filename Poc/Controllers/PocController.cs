using Microsoft.AspNetCore.Mvc;

namespace Poc.Controllers;

public class PocController : BaseController
{
    public PocController(ILogger<LoginController> logger) : base(logger) { }

    public IActionResult Index()
    {
        TempData.Keep();
        return View();
    }

    public IActionResult Dashboard()
    {
        TempData.Keep();
        return View();
    }
}