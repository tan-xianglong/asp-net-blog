using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.ViewModels
{
    public class PostViewModel
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

        public IEnumerable<Comment> Comments { get; set; }
    }
}
