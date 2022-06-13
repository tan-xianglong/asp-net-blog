using Data.Entities;
using Domain;

namespace Blog.Models.ViewModels.Home
{
    public class HomeViewModel
    {
        public PaginatedList<Post> Posts { get; set; }
    }
}
