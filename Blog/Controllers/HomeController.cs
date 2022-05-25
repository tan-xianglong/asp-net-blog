
using Blog.Models.ViewModels;
using Blog.Models.ViewModels.Home;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostServices _postServices;

        public HomeController(IPostServices postServices)
        {
            _postServices = postServices;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            var posts = await _postServices.GetPaginatedPostsAsync(pageNumber, null);
            return View(new HomeViewModel
            {
                Posts = posts
            });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
