using Blog.Helpers;
using Blog.Models;
using Blog.Models.ViewModels;
using Blog.Models.ViewModels.Posts;
using Blog.Services;
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
        private readonly IPostServices _postServices;

        [TempData]
        public string Message { get; set; }

        public PostsController(IPostRepository postRepository, IPostServices postServices)
        {
            _postRepository = postRepository;
            _postServices = postServices;
        }
        public async Task<IActionResult> Index(string currentSearch, string searchString, int? pageNumber)
        {
            try
            {   
                var posts = await _postServices.GetPaginatedPostsAsync(pageNumber, searchString, currentSearch);
                currentSearch = _postServices.GetCurrentSearch(searchString, currentSearch);
                return View(new PostIndexViewModel
                {
                    Message = this.Message,
                    Posts = posts,
                    CurrentSearch = currentSearch
                });
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
                var post = await _postServices.GetPostViewModelAsync(postId);
                if (post == null)
                {
                    TempData["Message"] = "Post not found.";
                    RedirectToAction("Index");
                }
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
            {   var id = postId ?? null;
                var post = await _postServices.GetPostViewModelAsync(id);
                return View(post);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel post)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(post);
                }
                await _postServices.SavePostAsync(post);
                TempData["Message"] = "Post has been saved!";
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
                var msg = await _postServices.DeletePostAsync(postId);
                TempData["message"] = msg;
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
