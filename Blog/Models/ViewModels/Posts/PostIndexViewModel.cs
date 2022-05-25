using Blog.Helpers;

namespace Blog.Models.ViewModels.Posts
{
    public class PostIndexViewModel
    {
        public string Message { get; set; }

        public string CurrentSearch { get; set; }

        public PaginatedList<Post> Posts { get; set; }
    }
}
