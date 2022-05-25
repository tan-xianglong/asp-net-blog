using Blog.Helpers;
using Blog.Models;
using Blog.Models.ViewModels.Posts;
using System.Threading.Tasks;

namespace Blog.Services
{
    public class PostServices : IPostServices
    {
        private readonly IPostRepository _postRepository;

        public PostServices(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PaginatedList<Post>> GetPaginatedPostsAsync(
            int? pageNumber,
            string searchString,
            string currentSearch)
        {
            if(searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentSearch;
            }
            
            int pageSize = 3;
            var posts = await _postRepository.GetPostsByNameAsync(searchString);
            return PaginatedList<Post>.Create(posts, pageNumber ?? 1, pageSize);
        }

        public string GetCurrentSearch(string searchString, string currentSearch)
        {
            if(searchString != null) currentSearch = searchString;
            return currentSearch;
        }

        public async Task<PostViewModel> GetPostViewModelAsync(int? postId)
        {
            PostViewModel postViewModel;
            if(!postId.HasValue)
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
                Subtitle =postViewModel.Subtitle,
                Content = postViewModel.Content,
                CreateDate = postViewModel.CreateDate
            };
            if(post.PostId > 0)
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
