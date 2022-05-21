using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Post>> AllPostAsync()
        {
            return await _appDbContext.Posts
                .OrderByDescending(p => p.CreateDate)
                .ToListAsync();
        }

        public Post Add(Post post)
        {
            _appDbContext.Posts.Add(post);
            return post;
        }

        public async Task<int> CommitAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }

        public Post Delete(int postId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            return await _appDbContext.Posts.FirstOrDefaultAsync(p => p.PostId == postId);
        }

        public async Task<IEnumerable<Post>> GetPostsByNameAsync(string name)
        {
            var query = from p in _appDbContext.Posts
                        where p.Title.Contains(name) || string.IsNullOrEmpty(name)
                        orderby p.CreateDate
                        select p;

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByTagAsync(string tag)
        {
            var query = from p in _appDbContext.Posts
                        where p.Tags.Contains(tag) || string.IsNullOrEmpty(tag)
                        orderby p.CreateDate
                        select p;

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
