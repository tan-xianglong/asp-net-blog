﻿using Blog.Helpers;
using Blog.Models;
using Blog.Models.ViewModels.Posts;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface IPostServices
    {
        Task<PaginatedList<Post>> GetPaginatedPostsAsync(
            int? pageNumber,
            string searchString,
            string currentSearch);

        string GetCurrentSearch(string searchString, string currentSearch);

        Task<PostViewModel> GetPostViewModelAsync(int? postId);

        Task<PostViewModel> SavePostAsync(int? postId)
    }
}