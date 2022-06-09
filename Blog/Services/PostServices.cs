using Blog.Helpers;
using Blog.Models;
using Blog.Models.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class PostServices : IPostServices
    {
        private readonly HttpClient _httpClient;
        private const string apiRoot = "https://localhost:5011";

        public PostServices()
        {
            _httpClient = new HttpClient();
        }

        public async Task<PaginatedList<Post>> GetPaginatedPostsAsync(
            int? pageNumber,
            string searchString)
        {
            if (pageNumber == null) pageNumber = 1;
            
            int pageSize = 3;

            //call into API
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{apiRoot}/api/Post/list/{searchString}");
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //deserialize content
            var content = await response.Content.ReadAsStringAsync();
            var posts = JsonSerializer.Deserialize<IEnumerable<Post>>(content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return PaginatedList<Post>.Create(posts, pageNumber ?? 1, pageSize);
        }

        public async Task<PostViewModel> GetPostViewModelAsync(int? postId)
        {
            PostViewModel postViewModel;
            if(!postId.HasValue)
            {
                postViewModel = new PostViewModel();
            }
            else
            {
                //call into API
                var request = new HttpRequestMessage(HttpMethod.Get,
                    $"{apiRoot}/api/Post/detail/{postId}");
                request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                //deserialize content
                var content = await response.Content.ReadAsStringAsync();
                postViewModel = JsonSerializer.Deserialize<PostViewModel>(content,
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
            }

            return postViewModel;
        }

        public async Task<string> SavePostAsync(PostViewModel postViewModel)
        {
            try
            {
                var response = await _httpClient
                    .PostAsJsonAsync($"{apiRoot}/api/Post/edit", postViewModel);
                response.EnsureSuccessStatusCode();
                return "Post has been saved.";
            }
            catch (Exception)
            {
                return "Post has not been saved.";
            }
            //call into API

        }

        public async Task<string> DeletePostAsync(int postId)
        {
            try
            {
                // call into API
                var response = await _httpClient.DeleteAsync($"{apiRoot}/api/Post/delete/{postId}");
                response.EnsureSuccessStatusCode();
                return "Blog post deleted.";
            }
            catch (Exception)
            {
                return "Blog post not found.";
            }
        }
    }
}
