using Blog.Helpers;
using Blog.Models;
using Blog.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> Index(string currentSearch, string searchString, int? pageNumber)
        {
            try
            {   
                if (searchString != null)
                {
                    pageNumber = 1;
                }
                else
                {
                    searchString = currentSearch;
                }
                ViewData["CurrentSearch"] = searchString;
                var posts = await _postRepository.GetPostsByNameAsync(searchString);
                int pageSize = 3;
                ViewBag.Message = message;
                return View(PaginatedList<Post>.Create(posts, pageNumber ?? 1, pageSize));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        public async Task<IActionResult> Detail(int postId)
        {
            try
            {
                var post = await _postRepository.GetPostByIdAsync(postId);
                if(post == null) return NotFound();
                return View(post);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? postId)
        {
            try
            {
                Post post;
                if (!postId.HasValue)
                {
                    post = new Post();
                } 
                else
                {
                    post = await _postRepository.GetPostByIdAsync(postId.Value);
                    if (post == null) return NotFound();
                }
                return View(post);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            try
            {   
                post.CreateDate = DateTime.Now;
                if(post.PostId > 0)
                {
                    _postRepository.Update(post);
                }
                else
                {
                    _postRepository.Add(post);
                }
                await _postRepository.CommitAsync();
                TempData["message"] = "Post has been saved!";
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int postId)
        {
            try
            {
                var post = await _postRepository.DeleteAsync(postId);
                await _postRepository.CommitAsync();
                if(post == null) return NotFound();
                TempData["message"] = "Blog post deleted.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
