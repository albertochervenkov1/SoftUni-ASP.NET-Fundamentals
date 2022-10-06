using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Data;
using ShoppingListApp.Data.Models;
using ShoppingListApp.Models;

namespace ShoppingListApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShoppiListDbContext dbContext;

        public ProductController(ShoppiListDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All()
        {
             var products = await dbContext.Products
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToListAsync();

              return View(products);
        }

        [HttpPost]
        public  IActionResult Add(ProductFormModel model)
        {
            var product =new Product()
            {
                Name = model.Name
            };

            dbContext.Products.AddRange(product);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(All));
        }
    }
}
