using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CBLSummerBlog07132016.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset? UpdateDate { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required]
        [AllowHtml]
        public string BodyText { get; set; }
        public string MediaUrl { get; set; }
        public bool Published { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
