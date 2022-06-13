using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Services;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostServicesWebApi _postServices;

        public PostController(IPostServicesWebApi postServices)
        {
            _postServices = postServices;
        }

        [HttpGet("list/{searchString?}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetList(string searchString)
        {
            try
            {
                var posts = await _postServices
                    .GetPostsByNameAsync(searchString);
                if (posts == null) return NotFound();
                return Ok(posts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("detail/{postId}")]
        public async Task<ActionResult<PostViewModel>> GetPost(int postId)
        {
            try
            {
                var post = await _postServices
                    .GetPostViewModelAsync(postId);
                if (post == null) return NotFound();
                return Ok(post);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost("edit")]
        public async Task<IActionResult> SavePost(PostViewModel post)
        {
            try
            {
                await _postServices.SavePostAsync(post);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpDelete("delete/{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            try
            {
                var post = await _postServices.DeletePostAsync(postId);
                return post == null ?  NotFound() : Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
