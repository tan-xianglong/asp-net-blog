using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Post Add(Post post)
        {
            _appDbContext.Posts.Add(post);
            return post;
        }

        public async Task<IEnumerable<Post>> AllPostAsync()
        {
            return await _appDbContext.Posts
                .OrderByDescending(p => p.CreateDate)
                .ToListAsync();
        }

        public async Task<int> CommitAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<Post> DeleteAsync(int postId)
        {
            var post = await GetPostByIdAsync(postId);
            if (post != null)
            {
                _appDbContext.Posts.Remove(post);
            }
            return post;
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            return await _appDbContext.Posts.Include(c => c.Comments)
                .FirstOrDefaultAsync(p => p.PostId == postId);
        }

        public async Task<IEnumerable<Post>> GetPostsByNameAsync(string name)
        {
            var query = _appDbContext.Posts
                .Where(p => string.IsNullOrEmpty(name) || p.Title.Contains(name))
                .OrderByDescending(p => p.CreateDate);

            return await query.ToListAsync();
        }

        public Post Update(Post post)
        {
            var entity = _appDbContext.Posts.Attach(post);
            entity.State = EntityState.Modified;
            return post;
        }
    }
}
