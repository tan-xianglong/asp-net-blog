using Blog.Helpers;
using Blog.Models;

namespace WebAPI.ViewModels
{
    public class HomeViewModel
    {
        public PaginatedList<Post> Posts { get; set; }
    }
}
