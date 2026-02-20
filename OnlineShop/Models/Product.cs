namespace OnlineShop.Models
{
    public class Product
    {
        public Product()
        {
            CreatedDate = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        public string? ImageUrl { get; set; }
        public int Stock {  get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
     