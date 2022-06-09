using Blog.Helpers;
using Blog.Models;

namespace WebAPI.ViewModels
{
    public class PostIndexViewModel
    {
        public string Message { get; set; }

        public string CurrentSearch { get; set; }

        public PaginatedList<Post> Posts { get; set; }
    }
}
