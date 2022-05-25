
using Blog.Models.ViewModels;
using Blog.Models.ViewModels.Home;
using Blog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                var posts = await _postServices.GetPaginatedPostsAsync(pageNumber, null, null);
                return View(new HomeViewModel
                {
                    Posts = posts
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
