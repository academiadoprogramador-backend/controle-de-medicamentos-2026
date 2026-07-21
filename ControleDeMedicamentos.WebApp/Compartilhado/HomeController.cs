using Microsoft.AspNetCore.Mvc;

namespace ControleDeMedicamentos.WebApp.Compartilhado;

public class HomeController : Controller
{
    // Ações = Métodos
    public ActionResult Index()
    {
        return View();
    }
}
