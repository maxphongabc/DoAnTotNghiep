using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class CommentProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 300, ErrorMessage = "Độ Dài khong phù hợp", MinimumLength = 16)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }
        public int IdProduct { get; set; }
        public virtual ProductModel Product { get; set; }
        public int IdUser { get; set; }
        public virtual UserModel User { get; set; }
        public bool Status { get; set; }
    }
}
