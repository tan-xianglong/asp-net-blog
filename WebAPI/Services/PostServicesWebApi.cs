using Data;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.ViewModels;

namespace WebAPI.Services
{
    public class PostServicesWebApi : IPostServicesWebApi
    {
        private readonly IPostRepository _postRepository;

        public PostServicesWebApi(IPostRepository postRepository)
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
                if (post == null)
                {
                    return null;
                }
                var commentList = new List<CommentViewModel>();
                foreach (var comment in post.Comments)
                {
                    commentList.Add(new CommentViewModel
                    {
                        Author = comment.Author,
                        Body = comment.Body,
                        Email = comment.Email,
                        CommentId = comment.CommentId,
                        CreateDate = comment.CreateDate,
                        PostId = comment.PostId
                    });
                }
                postViewModel = new PostViewModel
                {
                    PostId = post.PostId,
                    Content = post.Content,
                    Title = post.Title,
                    Subtitle = post.Subtitle,
                    CreateDate = post.CreateDate,
                    Comments = commentList
                };
            }

            return postViewModel;
        }

        public async Task<int> SavePostAsync(PostViewModel postViewModel)
        {
            var post = new Post
            {
                PostId = postViewModel.PostId,
                Title = postViewModel.Title,
                Subtitle = postViewModel.Subtitle,
                Content = postViewModel.Content,
                CreateDate = System.DateTime.Now
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
