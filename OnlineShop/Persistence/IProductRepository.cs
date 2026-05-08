using OnlineShop.Models;

namespace OnlineShop.Persistence
{
    public interface IProductRepository
    {
        public void Add(Product product);
        public List<Product> GetAll();
        public Product Get(int id);
        public void Delete(Product product);
        int Update(Product product);
    }
}
