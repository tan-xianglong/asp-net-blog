using Data;
using Data.Entities;
using System.Threading.Tasks;
using WebAPI.ViewModels;

namespace WebAPI.Services
{
    public class CommentServicesWebApi : ICommentServicesWebApi
    {
        private readonly ICommentRepository _commentRepository;

        public CommentServicesWebApi(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<Comment> DeleteCommentAsync(int commentId)
        {
            var comment = await _commentRepository.DeleteAsync(commentId);
            await _commentRepository.CommitAsync();
            return comment;
        }

        public async Task<int> SaveCommentAsync(CommentViewModel commentViewModel)
        {
            var comment = new Comment
            {
                Author = commentViewModel.Author,
                Body = commentViewModel.Body,
                Email = commentViewModel.Email,
                PostId = commentViewModel.PostId,
                CreateDate = System.DateTime.Now
            };

            _commentRepository.Add(comment);

            return await _commentRepository.CommitAsync();
        }
    }
}
