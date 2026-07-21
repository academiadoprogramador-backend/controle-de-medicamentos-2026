using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.WebApp.Controllers;

public class HomeController : Controller
{
    // Ações = Métodos
    public ActionResult Index()
    {
        return View();
    }
}
