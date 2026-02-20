namespace OnlineShop.ViewModels
{
    public class ProductAddViewModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        //public string? ImageUrl { get; set; }
        public int Stock { get; set; }
    }
}
