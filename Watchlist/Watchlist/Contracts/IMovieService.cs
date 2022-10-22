using Microsoft.AspNetCore.Mvc;
using Watchlist.Data.Models;
using Watchlist.Models;

namespace Watchlist.Contracts
{
    public interface IMovieService
    {
        Task AddMovieAsync(AddMovieViewModel model);
        Task<IEnumerable<Genre>> GetGenresAsync();

        Task<IEnumerable<AllMovieModel>> GetAllAsync();
        Task<IEnumerable<AllMovieModel>> GetWatchedAsync(string userId);

        Task AddMovieToCollection(string userId, int movieId);

        Task RemoveMovieFromCollection(string userId, int movieId);

    }
}
