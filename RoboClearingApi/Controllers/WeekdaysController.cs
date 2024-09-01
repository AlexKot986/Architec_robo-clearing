using Microsoft.AspNetCore.Mvc;

namespace RoboClearingApi.Controllers;

public class WeekdaysController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}