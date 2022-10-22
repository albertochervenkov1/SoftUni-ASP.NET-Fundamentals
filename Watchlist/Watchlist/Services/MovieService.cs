using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Watchlist.Contracts;
using Watchlist.Data;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Services
{
    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext _context)
        {
            context = _context;
        }


        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            var movie = new Movie()
            {
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId,
            };
            await context.Movies.AddAsync(movie);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task<IEnumerable<AllMovieModel>> GetAllAsync()
        {
            var entities = await context.Movies
                .Include(m => m.Genre)
                .ToListAsync();

            return entities
                .Select(m => new AllMovieModel()
                {
                    Director = m.Director,
                    Genre = m?.Genre?.Name,
                    Id = m.Id,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Title = m.Title
                });
        }

        public async Task<IEnumerable<AllMovieModel>> GetWatchedAsync(string userId)
        {
            var user=await context.Users
                .Where(u=>u.Id==userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(um => um.Movie)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync();

            if (user==null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.UsersMovies
                .Select(m => new AllMovieModel()
                {
                    Director = m.Movie.Director,
                    Genre = m.Movie.Genre?.Name,
                    Id = m.MovieId,
                    ImageUrl = m.Movie.ImageUrl,
                    Title = m.Movie.Title,
                    Rating = m.Movie.Rating,
                });
        }

        public async Task AddMovieToCollection(string userId, int movieId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var movie = await context.Movies.FirstOrDefaultAsync(u => u.Id == movieId);

            if (movie == null)
            {
                throw new ArgumentException("Invalid Movie ID");
            }

            if (!(user.UsersMovies.Any(m => m.MovieId == movieId)))
            {
                user.UsersMovies.Add(new UserMovie()
                {
                    MovieId = movie.Id,
                    UserId = user.Id,
                    Movie = movie,
                    User = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveMovieFromCollection(string userId, int movieId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var movie = user.UsersMovies.FirstOrDefault(um => um.MovieId == movieId);

            if (movie != null)
            {
                user.UsersMovies.Remove(movie);

                await context.SaveChangesAsync();
            }
        }
    }
}
