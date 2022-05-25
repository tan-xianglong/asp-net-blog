using Blog.Helpers;
using Blog.Models;
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

    }
}
