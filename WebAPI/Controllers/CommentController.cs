using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPI.Services;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentServicesWebApi _commentServicesWebApi;

        public CommentController(ICommentServicesWebApi commentServicesWebApi)
        {
            _commentServicesWebApi = commentServicesWebApi;
        }

        [HttpPost("new")]
        public async Task<IActionResult> SaveComment([FromBody]CommentViewModel commentViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _commentServicesWebApi.SaveCommentAsync(commentViewModel);
                    return Ok();
                }
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            return BadRequest("Invalid Comment Model Input");
        }


        [HttpDelete("delete/{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            try
            {
                var comment = await _commentServicesWebApi.DeleteCommentAsync(commentId);
                return comment == null ? NotFound() : Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
            
        }
    }
}
