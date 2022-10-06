namespace ShoppingListApp.Data.Models
{
    public class Product
    {
        public Product()
        {
            IList<ProductNote> productNotes=new List<ProductNote>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ProductNote> ProductNotes { get; set; }
    }
}
