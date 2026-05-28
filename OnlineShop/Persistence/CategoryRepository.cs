using Microsoft.EntityFrameworkCore;
using OnlineShop.Models; 

namespace OnlineShop.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private ShopContext _shopContext;

        public CategoryRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<Category> GetAll()
        {
            return _shopContext.Categories.ToList();
        }

        public Category? Get(int id)
        {
            return _shopContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public int Add(Category category)
        {
            _shopContext.Categories.Add(category);
            return _shopContext.SaveChanges();
        }
        public int Update(Category category)
        {
            _shopContext.Categories.Update(category);
            return _shopContext.SaveChanges();
        }

        public int Delete(Category category)
        {
            _shopContext.Categories.Remove(category);
            return _shopContext.SaveChanges();
        }
    }
}
