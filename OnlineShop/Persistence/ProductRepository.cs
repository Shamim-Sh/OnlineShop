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

        public int Add(Product product)
        {
            _shopContext.Products.Add(product);
            return _shopContext.SaveChanges();
        }
        public int Delete(Product product)
        {
            _shopContext.Products.Remove(product);
            return _shopContext.SaveChanges();
        }
        public List<Product> GetAll()
        {
            var data = _shopContext.Products.ToList(); // method syntax

            var data2 = from p in _shopContext.Products // query syntax
                                                        //where p.Name =="kala"
                        select p;


            return _shopContext.Products.ToList();
        }

        public Product? Get(int id)
        {
            return _shopContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public int Update(Product product)
        {
            _shopContext.Products.Update(product);
            return _shopContext.SaveChanges();
        }
    }
}
