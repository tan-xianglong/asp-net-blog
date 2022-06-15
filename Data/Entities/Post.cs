 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        [Required(ErrorMessage = "Please enter the title of the blog.")]
        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Subtitle { get; set; }
        [Required(ErrorMessage = "Please provide the body of the blog article.")]
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }

        // New relationship property
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
