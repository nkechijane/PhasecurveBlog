using Microsoft.AspNetCore.Mvc;

namespace PhasecurveBlog.Controllers;

public class AuthorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}