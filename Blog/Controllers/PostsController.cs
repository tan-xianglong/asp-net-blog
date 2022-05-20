using Blog.Models;
using Blog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _postRepository;

        [TempData]
        public string message { get; set; }

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            return View();
        }
    }
}
