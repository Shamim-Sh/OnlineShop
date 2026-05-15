using OnlineShop.Models;

namespace OnlineShop.Persistence
{
    public interface IProductRepository
    {
        int Add(Product product);
        List<Product> GetAll();
        Product Get(int id);
        int Delete(Product product);
        int Update(Product product);
    }
}
