using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<Product> GetAll()
        {
            return _shopContext.Products.Include(x => x.Category).ToList();
        }

        public Product? Get(int id)
        {
            return _shopContext.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public int Add(Product product)
        {
            _shopContext.Products.Add(product);
            return _shopContext.SaveChanges();
        }

        public int Update(Product product)
        {
            _shopContext.Products.Update(product);
            return _shopContext.SaveChanges();
        }

        public int Delete(Product product)
        {
            _shopContext.Products.Remove(product);
            return _shopContext.SaveChanges();
        }
    }
}
