using System.ComponentModel.DataAnnotations;

namespace Common.Model
{
    public class FeedBackModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 500, ErrorMessage = "Viết ngắn ngắn hoy", MinimumLength = 5)]
        public string Content { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
