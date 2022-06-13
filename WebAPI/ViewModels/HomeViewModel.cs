using Data.Entities;
using Domain;

namespace WebAPI.ViewModels
{
    public class HomeViewModel
    {
        public PaginatedList<Post> Posts { get; set; }
    }
}
