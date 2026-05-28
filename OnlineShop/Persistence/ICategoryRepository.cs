using OnlineShop.Models;

namespace OnlineShop.Persistence
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category Get(int id);
        int Add(Category category);
        int Update(Category category);
        int Delete(Category category);
    }
}
