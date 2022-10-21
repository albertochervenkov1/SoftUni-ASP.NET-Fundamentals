using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Watchlist.Data.Common;

namespace Watchlist.Data.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MovieConstraints.TITLE_MAX_LENGTH)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MovieConstraints.DIRECTOR_MAX_LENGTH)]
        public string Director { get; set; } = null!;

        [Required] 
        public string ImageUrl { get; set; } = null!;

        public decimal Rating { get; set; }

        public int GenreId { get; set; }
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }

        public ICollection<UserMovie> UserMovies { get; set; } = new List<UserMovie>();



        //•	Has Id – a unique integer, Primary Key
        //•	Has Title – a string with min length 10 and max length 50 (required)
        //•	Has Director – a string with min length 5 and max length 50 (required)
        //•	Has ImageUrl – a string (required)
        //•	Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
        //•	Has GenreId – an integer(required)
        //    •	Has Genre – a Genre(required)
        //    •	Has UsersMovies – a collection of type UserMovie

    }
}
