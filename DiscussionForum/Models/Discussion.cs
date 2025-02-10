using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscussionForum.Models
{
    public class Discussion
    {
        public int DiscussionId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty; 

        [Required]
        public string Content { get; set; } = string.Empty; 

        public string? ImageFileName { get; set; } 

        public DateTime CreateDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}