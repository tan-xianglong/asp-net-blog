using Blog.Helpers;
using Blog.Models;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface IPostServices
    {
        Task<PaginatedList<Post>> GetPaginatedPostsAsync(
            int? pageNumber,
            string searchString,
            string currentSearch);

        string GetCurrentSearch(string searchString, string currentSearch);
    }
}