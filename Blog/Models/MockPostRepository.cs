using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Models
{
    public class MockPostRepository : IPostRepository
    {
        public IEnumerable<Post> AllPost => 
            new List<Post>
            {
                new Post {PostId = 1, Title = "Man must explore, and this is exploration at its greatest", Subtitle = "Problems look mighty small from 150 miles up", Content = "Loren Ipsum", CreateDate = DateTime.Now, Tags = new List<string> {"exploration", "moon"}},
                new Post {PostId = 2, Title = "I believe every human has a finite number of heartbeats. I don't intend to waste any of mine.", Content = "Loren Ipsum", CreateDate = DateTime.Now, Tags = new List<string> {"biology", "moon", "science"}},
                new Post {PostId = 3, Title = "Science has not yet mastered prophecy", Subtitle = "We predict too much for the next year and yet far too little for the next ten.", Content = "Loren Ipsum", CreateDate = DateTime.Now, Tags = new List<string> {"science", "exploration"}},
                new Post {PostId = 4, Title = "Failure is not an option", Subtitle = "Many say exploration is part of our destiny, but it’s actually our duty to future generations.", Content = "Loren Ipsum", CreateDate = DateTime.Now},
                new Post {PostId = 5, Title = "Science has not yet mastered prophecy", Subtitle = "We predict too much for the next year and yet far too little for the next ten.", Content = "Loren Ipsum", CreateDate = DateTime.Now, Tags = new List<string> {"science", "exploration"}}
            };

        public Post Add(Post post)
        {
            throw new System.NotImplementedException();
        }

        public int Commit()
        {
            throw new System.NotImplementedException();
        }

        public Post Delete(int postId)
        {
            throw new System.NotImplementedException();
        }

        public Post GetPostById(int postId)
        {
            return AllPost.FirstOrDefault(p => p.PostId == postId);
        }

        public IEnumerable<Post> GetPostsByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Post> GetPostsByTag(string tag)
        {
            throw new System.NotImplementedException();
        }

        public Post Update(Post post)
        {
            throw new System.NotImplementedException();
        }
    }
}
