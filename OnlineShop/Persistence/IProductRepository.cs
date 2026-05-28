using OnlineShop.Models;

namespace OnlineShop.Persistence
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? Get(int id);
        int Add(Product product);
        int Update(Product product);
        int Delete(Product product);
    }
}
