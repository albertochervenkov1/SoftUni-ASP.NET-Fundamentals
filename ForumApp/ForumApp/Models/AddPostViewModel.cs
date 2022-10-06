using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models
{
    public class AddPostViewModel
    {
        [Required]
        [StringLength(Constants.DataConstants.Post.TITLE_MAX_LENGTH, MinimumLength = 10)]

        public string Title { get; set; }

        [Required]
        [StringLength(Constants.DataConstants.Post.CONTENT_MAX_LENGTH, MinimumLength = 30)]
        public string Content { get; set; }
    }
}
