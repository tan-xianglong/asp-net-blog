using Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> AllPostAsync();
        Task<IEnumerable<Post>> GetPostsByNameAsync(string name);

        Task<Post> GetPostByIdAsync(int postId);

        Post Update(Post post);

        Post Add(Post post);

        Task<Post> DeleteAsync(int postId);

        Task<int> CommitAsync();
    }
}
