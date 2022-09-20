using Microsoft.AspNetCore.Mvc;

namespace EgnApp.Controllers
{
    public class EgnController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
