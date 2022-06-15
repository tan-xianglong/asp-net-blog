using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ICommentRepository
    {
        Task<Comment> GetCommentByIdAsync(int commentId);

        Comment Update(Comment comment);

        Comment Add(Comment comment);

        Task<Comment> DeleteAsync(int commentId);

        Task<int> CommitAsync();
    }
}
