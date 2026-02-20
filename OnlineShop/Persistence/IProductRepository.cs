using OnlineShop.Models;

namespace OnlineShop.Persistence
{
    public interface IProductRepository
    {
        public void Add(Product product);
        public List<Product> GetAll();
    }
}
