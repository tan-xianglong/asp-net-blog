using Data.Entities;
using Domain;

namespace WebAPI.ViewModels
{
    public class PostIndexViewModel
    {
        public string Message { get; set; }

        public string CurrentSearch { get; set; }

        public PaginatedList<Post> Posts { get; set; }
    }
}
