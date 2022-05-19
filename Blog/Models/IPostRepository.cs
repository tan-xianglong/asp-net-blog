using System.Collections.Generic;

namespace Blog.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> AllPost { get; }
        IEnumerable<Post> GetPostsByName(string name);

        IEnumerable<Post> GetPostsByTag(string tag);

        Post GetPostById(int postId);

        Post Update(Post post);

        Post Add(Post post);

        Post Delete(int postId);

        int Commit();
    }
}
