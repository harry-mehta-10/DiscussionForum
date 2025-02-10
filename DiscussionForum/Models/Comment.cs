using System;

namespace DiscussionForum.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int DiscussionId { get; set; }

        public string Author { get; set; } = string.Empty; 

        public virtual Discussion Discussion { get; set; } = new Discussion();
    }
}