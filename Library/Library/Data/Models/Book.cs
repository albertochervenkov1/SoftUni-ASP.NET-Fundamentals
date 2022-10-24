using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Common;

namespace Library.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(BookConstraints.TITLE_MAX_LENGTH)]
        public string Title { get; set; }=null!;

        [Required]
        [StringLength(BookConstraints.AUTHOR_MAX_LENGTH)]
        public string Author { get; set; }=null!;

        [Required]
        [StringLength(BookConstraints.DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }=null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        
    }
}
