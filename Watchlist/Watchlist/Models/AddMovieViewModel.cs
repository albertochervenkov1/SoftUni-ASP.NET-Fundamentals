using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Common;
using Watchlist.Data.Models;

namespace Watchlist.Models
{
    public class AddMovieViewModel
    {
        [Required]
        [StringLength(MovieConstraints.TITLE_MAX_LENGTH, MinimumLength = MovieConstraints.TITLE_MIN_LENGTH)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(MovieConstraints.DIRECTOR_MAX_LENGTH, MinimumLength = MovieConstraints.DIRECTOR_MIN_LENGTH)]
        public string Director { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; }

        [Range(typeof(decimal), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }
        public int GenreId { get; set; }
        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
        

    }
}
