using Blog.Models.ViewModels.Posts;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface ICommentServices
    {
        Task<string> SaveCommentAsync(PostViewModel postViewModel);

        Task<string> DeleteCommentAsync(int commentId);
    }
}
