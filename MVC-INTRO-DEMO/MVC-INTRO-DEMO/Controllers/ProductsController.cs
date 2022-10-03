using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVC_INTRO_DEMO.Models;

namespace MVC_INTRO_DEMO.Controllers
{
    public class ProductsController : Controller
    {
        private HashSet<ProductViewModel> products = new HashSet<ProductViewModel>()
        {
            new ProductViewModel()
            {
                Id=1,
                Name = "Cheese",
                Price = 7.00
            },

            new ProductViewModel()
            {
                Id = 2,
                Name = "Ham",
                Price = 5.50
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Bread",
                Price = 1.50
            }

        };
        public IActionResult Index()
        {
            return View();
        }

        [ActionName("My-Products")]
        public IActionResult All(string keyword)
        {
            if (keyword!=null)
            {
                var foundProducts = products.Where(pr => pr.Name.ToLower().Contains(keyword.ToLower()));
                return View(foundProducts);
            }
            return View(this.products);
        }

        public IActionResult ById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            var text=string.Empty;
            foreach (var product in products)
            {
                text += $"Product {product.Id}: {product.Name} - {product.Price:f2}lv.";
                text +="\r\n";
            }

            return Content(text);
        }

        public  IActionResult AllAsTextFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price:f2}lv.");
            }
            Response.Headers.Add(HeaderNames.ContentDisposition,@"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
