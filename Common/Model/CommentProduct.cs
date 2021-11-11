using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Model
{
    public class CommentProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 500, ErrorMessage = "Viết ngắn ngắn hoy", MinimumLength = 5)]
        public string Content { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateOn { get; set; }
        public virtual ProductModel products { get; set; }
        public virtual CommentProduct cmt { get; set; }
        public virtual UserModel users { get; set; }
        public bool Status { get; set; }
    }
}
