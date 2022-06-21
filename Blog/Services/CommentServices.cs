using Blog.Models.ViewModels.Comments;
using Blog.Models.ViewModels.Posts;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class CommentServices : ICommentServices
    {
        private readonly HttpClient _httpClient;

        public CommentServices(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WebApi");
        }

        public async Task<string> DeleteCommentAsync(int commentId)
        {
            try
            {
                // call into API
                var response = await _httpClient.DeleteAsync($"api/Comment/delete/{commentId}");
                response.EnsureSuccessStatusCode();
                return "Comment deleted.";
            }
            catch (Exception)
            {
                return "Comment not found.";
            }
        }

        public async Task<string> SaveCommentAsync(PostViewModel postViewModel)
        {
            try
            {
                if (postViewModel.Comment.Author == null) postViewModel.Comment.Author = "Anonymous";
                CommentViewModel comment = new CommentViewModel
                {
                    PostId = postViewModel.Comment.PostId,
                    Author = postViewModel.Comment.Author,
                    Body = postViewModel.Comment.Body,
                    Email = postViewModel.Comment.Email
                };
                // call into API
                var response = await _httpClient.PostAsJsonAsync($"api/Comment/new/", comment);
                response.EnsureSuccessStatusCode();
                return "Comment has been saved.";
            }
            catch (Exception) //This is a general demonstration of catching errors.
            {
                return "Comment has not been found.";
            }
        }
    }
}
