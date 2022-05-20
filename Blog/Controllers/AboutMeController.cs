using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class AboutMeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
