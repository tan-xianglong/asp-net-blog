using Data.Entities;
using Domain;

namespace Blog.Models.ViewModels.Posts
{
    public class PostIndexViewModel
    {
        public string Message { get; set; }

        public string SearchString { get; set; }

        public PaginatedList<Post> Posts { get; set; }
    }
}
