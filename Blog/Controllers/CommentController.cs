using Blog.Models.ViewModels.Posts;
using Blog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentServices _commentServices;

        public CommentController(ICommentServices commentServices)
        {
            _commentServices = commentServices;
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostViewModel post)
        {
            try
            {
                string msg = "Invalid inputs. Comments have not been saved.";
                if (ModelState.IsValid)
                {
                    msg = await _commentServices.SaveCommentAsync(post);
                }
                TempData["Message"] = msg;
                return RedirectToAction("Detail", "Posts", new {postId = post.PostId});
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int commentId)
        {
            try
            {
                var msg = await _commentServices.DeleteCommentAsync(commentId);
                TempData["Message"] = msg;
                return RedirectToAction("Index", "Posts");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
