using Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.ViewModels;

namespace WebAPI.Services
{
    public interface IPostServicesWebAPI
    {
        Task<PostViewModel> GetPostViewModelAsync(int? postId);

        Task<int> SavePostAsync(PostViewModel postViewModel);

        Task<Post> DeletePostAsync(int postId);

        Task<IEnumerable<Post>> GetPostsByNameAsync(string name);
    }
}
