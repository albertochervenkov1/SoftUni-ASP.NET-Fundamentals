using System.ComponentModel.DataAnnotations;
using Library.Common;
using Library.Data.Models;

namespace Library.Models
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(BookConstraints.TITLE_MAX_LENGTH, MinimumLength = BookConstraints.TITLE_MIN_LENGTH)]
        public string Title { get; set; }
        [Required]
        [StringLength(BookConstraints.AUTHOR_MAX_LENGTH, MinimumLength = BookConstraints.AUTHOR_MIN_LENGTH)]
        public string Author { get; set; }
        [Required]
        [StringLength(BookConstraints.DESCRIPTION_MAX_LENGTH, MinimumLength = BookConstraints.DESCRIPTION_MIN_LENGTH)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        [Range(typeof(decimal), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
