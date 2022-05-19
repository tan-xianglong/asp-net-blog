using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [Required(ErrorMessage ="Please enter the title of the blog.")]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Subtitle { get; set; }
        [Required(ErrorMessage = "Please provide the body of the blog article.")]
        public string Content { get; set; }
        [Required]
        public List<string> Tags { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
