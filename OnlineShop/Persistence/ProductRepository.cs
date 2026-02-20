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

        public void Add(Product product)
        {
            _shopContext.Products.Add(product);
            _shopContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _shopContext.Products.ToList();
        }
    }
}
