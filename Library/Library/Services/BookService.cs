using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService:IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var entities = await context.Books
                .Include(m => m.Category)
                .ToListAsync();

            return entities
                .Select(b => new BookViewModel()
                {
                   Id = b.Id,
                   Author = b.Author,
                   ImageUrl = b.ImageUrl,
                   Rating = b.Rating,
                   Title = b.Title,
                   Category = b.Category.Name
                });
        }

        public async Task<IEnumerable<BookViewModel>> GetMineAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .ThenInclude(um => um.Book)
                .ThenInclude(m => m.Category)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return user.ApplicationUsersBooks
                .Select(b => new BookViewModel()
                {
                    Id = b.Book.Id,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description,
                    Rating = b.Book.Rating,
                    Title = b.Book.Title,
                    Category = b.Book.Category.Name
                });
        }

        public async Task AddBookToCollectionAsync(int bookId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var book = await context.Books.FirstOrDefaultAsync(u => u.Id == bookId);

            if (book == null)
            {
                throw new ArgumentException("Invalid Movie ID");
            }

            if (!(user.ApplicationUsersBooks.Any(m => m.BookId == bookId)))//possible error
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    BookId = book.Id,
                    ApplicationUserId = user.Id,
                    Book = book,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveBookFromCollectionAsync(int bookId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var movie = user.ApplicationUsersBooks.FirstOrDefault(m => m.BookId == bookId);

            if (movie != null)
            {
                user.ApplicationUsersBooks.Remove(movie);

                await context.SaveChangesAsync();
            }
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            var entity = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
            };

            await context.Books.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }
    }
}
