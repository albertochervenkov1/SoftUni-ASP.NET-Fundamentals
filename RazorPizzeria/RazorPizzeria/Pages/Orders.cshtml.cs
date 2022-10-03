using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Models;

namespace RazorPizzeria.Pages
{
    public class OrdersModel : PageModel
    {
        private readonly PizzeriaDbContext _context;
        public OrdersModel(PizzeriaDbContext context)
        {
            _context=context;
        }
        public List<PizzaOrder> PizzaOrders = new List<PizzaOrder>();
        
        public void OnGet()
        {
            PizzaOrders = _context.PizzaOrders.ToList();
        }
    }
}
