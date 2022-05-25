using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models.ViewModels.Posts
{
    public class PostViewModel
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Content { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
