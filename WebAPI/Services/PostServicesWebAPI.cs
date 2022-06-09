using Blog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.ViewModels;

namespace WebAPI.Services
{
    public class PostServicesWebAPI : IPostServicesWebAPI
    {
        private readonly IPostRepository _postRepository;

        public PostServicesWebAPI(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<Post> DeletePostAsync(int postId)
        {
            var post = await _postRepository.DeleteAsync(postId);
            await _postRepository.CommitAsync();
            return post;
        }

        public async Task<IEnumerable<Post>> GetPostsByNameAsync(string name)
        {
            return await _postRepository.GetPostsByNameAsync(name);
        }

        public async Task<PostViewModel> GetPostViewModelAsync(int? postId)
        {
            PostViewModel postViewModel;
            if (!postId.HasValue)
            {
                postViewModel = new PostViewModel();
            }
            else
            {
                var post = await _postRepository.GetPostByIdAsync(postId.Value);
                postViewModel = new PostViewModel
                {
                    PostId = post.PostId,
                    Content = post.Content,
                    Title = post.Title,
                    Subtitle = post.Subtitle,
                    CreateDate = post.CreateDate
                };
            }

            return postViewModel;
        }

        public async Task<int> SavePostAsync(PostViewModel postViewModel)
        {
            postViewModel.CreateDate = System.DateTime.Now;
            var post = new Post
            {
                PostId = postViewModel.PostId,
                Title = postViewModel.Title,
                Subtitle = postViewModel.Subtitle,
                Content = postViewModel.Content,
                CreateDate = postViewModel.CreateDate
            };
            if (post.PostId > 0)
            {
                _postRepository.Update(post);
            }
            else
            {
                _postRepository.Add(post);
            }
            return await _postRepository.CommitAsync();
        }
    }
}
