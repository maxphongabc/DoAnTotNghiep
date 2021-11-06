using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Model
{
    public class CommentBlogModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 500, ErrorMessage = "Viết ngắn ngắn hoy", MinimumLength = 5)]
        public string Content { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateOn { get; set; }
        public virtual BlogModel blogs { get; set; }
        public virtual UserModel users { get; set; }
        public bool Status { get; set; }
    }
}
