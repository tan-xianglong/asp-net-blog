using System.Collections.Generic;

namespace Blog.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}
