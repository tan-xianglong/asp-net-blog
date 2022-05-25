using Blog.Helpers;

namespace Blog.Models.ViewModels.Home
{
    public class HomeViewModel
    {
        public PaginatedList<Post> Posts { get; set; }
    }
}
