using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _appDbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Comment Add(Comment comment)
        {
            _appDbContext.Comments.Add(comment);
            return comment;
        }

        public async Task<int> CommitAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<Comment> DeleteAsync(int commentId)
        {
            var comment = await GetCommentByIdAsync(commentId);
            if (comment != null)
            {
                _appDbContext.Comments.Remove(comment);
            }
            return comment;
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _appDbContext.Comments
                .FirstOrDefaultAsync(p => p.CommentId == commentId);
        }

        public Comment Update(Comment comment)
        {
            var entity = _appDbContext.Comments.Attach(comment);
            entity.State = EntityState.Modified;
            return comment;
        }
    }
}
