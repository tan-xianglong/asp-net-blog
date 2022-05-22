using Blog.Models;
using Blog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index(string searchString)
        {
            //ViewData["CurrentFilter"] = searchString;
            var posts = await _postRepository.GetPostsByNameAsync(searchString);
            ViewBag.Message = message;
            return View(posts);
        }

        public async Task<IActionResult> Detail(int postId)
        {   
            var post = await _postRepository.GetPostByIdAsync(postId);
            return View(post);
        }


    }
}
