using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTest.Services
{
    public class PostTestDataRepository : IPostRepository
    {
        private List<Post> _posts;

        public PostTestDataRepository()
        {
            _posts = new List<Post>()
            {
                new Post()
                {
                    PostId = 1,
                    Title = "Man must explore, and this is exploration at its greatest",
                    Subtitle = "Problems look mighty small from 150 miles up",
                    Content = "Loren Ipsum",
                    CreateDate = DateTime.Now
                },
                new Post()
                {
                    PostId = 2,
                    Title = "I believe every human has a finite number of heartbeats. I don't intend to waste any of mine.",
                    Content = "Loren Ipsum",
                    CreateDate = DateTime.Now
                },
                new Post()
                {
                    PostId = 3,
                    Title = "Science has not yet mastered prophecy",
                    Subtitle = "We predict too much for the next year and yet far too little for the next ten.",
                    Content = "Loren Ipsum",
                    CreateDate = DateTime.Now
                }
            };


        }

        public Post Add(Post post)
        {
            _posts.Add(post);
            return post;
        }

        public Task<IEnumerable<Post>> AllPostAsync()
        {
            return Task.FromResult(_posts.AsEnumerable());
        }

        public Task<int> CommitAsync()
        {
            return Task.FromResult(1);
        }

        public Task<Post> DeleteAsync(int postId)
        {
            return Task.FromResult(_posts[0]);
        }

        public Task<Post> GetPostByIdAsync(int postId)
        {
            return Task.FromResult(_posts[0]);
        }

        public Task<IEnumerable<Post>> GetPostsByNameAsync(string name)
        {
            return Task.FromResult(_posts.AsEnumerable());
        }

        public Post Update(Post post)
        {
            return _posts[0];
        }
    }
}
