using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Models
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> AllPostAsync();
        Task<IEnumerable<Post>> GetPostsByNameAsync(string name);

        Task<IEnumerable<Post>> GetPostsByTagAsync(string tag);

        Task<Post> GetPostByIdAsync(int postId);

        Post Update(Post post);

        Post Add(Post post);

        Post Delete(int postId);

        Task<int> CommitAsync();
    }
}
