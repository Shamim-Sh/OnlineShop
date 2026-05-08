using System.Xml.Linq;

namespace OnlineShop.ViewModels
{
    public class ProductUpdateViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
    //public record ProductUpdateViewModel(int Id, string Name, string? Description, int Price, int Stock);
   
}
