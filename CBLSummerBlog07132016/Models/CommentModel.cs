using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CBLSummerBlog07132016.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorID { get; set; }
        public string CommentBodyText { get; set; }
        public DateTimeOffset CommentCreateDate { get; set; }
        public DateTimeOffset? CommentUpdateDate { get; set; }
        public string UpdateReason { get; set; }

        public virtual ApplicationUser Author { get; set; }
        public virtual BlogPost Post { get; set; }
    }
}
