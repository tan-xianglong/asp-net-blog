using Data.Entities;
using System.Threading.Tasks;
using WebAPI.ViewModels;

namespace WebAPI.Services
{
    public interface ICommentServicesWebApi
    {
        Task<int> SaveCommentAsync(CommentViewModel commentViewModel);

        Task<Comment> DeleteCommentAsync(int commentId);
    }
}
