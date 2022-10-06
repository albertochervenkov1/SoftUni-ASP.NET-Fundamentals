using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static ForumApp.Constants.DataConstants.Post;

namespace ForumApp.Data.Models
{
    [Comment("Published posts")]
    public class Post
    {
        [Key]
        [Comment("Post Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TITLE_MAX_LENGTH)]
        [Comment("Post Title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(CONTENT_MAX_LENGTH)]
        [Comment("Post content")]
        public string Content { get; set; } = null!;

        [Required]
        [Comment("Marks record as deleted")]
        public bool IsDeleted { get; set; } = false;

    }
}
