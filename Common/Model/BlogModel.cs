using Common.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model
{
    public class BlogModel
    {
        public int Id { get; set; }
        public int Category_PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Brief { get; set; }
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public string Image { get; set; }
        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
        public bool Status { get; set; }
        public virtual Category_PostModel Category_Post { get; set; }
        public ICollection<CommentBlogModel> commentBlogs { get; set; }
        public virtual UserModel User { get; set; }

    }
}
