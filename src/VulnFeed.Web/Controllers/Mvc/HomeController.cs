using Microsoft.AspNetCore.Mvc;

namespace VulnFeed.Web.Controllers.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
}
