using System.ComponentModel.DataAnnotations;

namespace RazorPizzeria.Models
{
    public class PizzaOrder
    {
        [Key]
        public int Id { get; set; }

        public string PizzaName { get; set; }
        public float BasePrice { get; set; }

    }
}
