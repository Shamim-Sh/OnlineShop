using OnlineShop.Persistence;
using OnlineShop.ViewModels;

namespace OnlineShop.Application
{
    public interface ICategoryService
    {

        List<CategoryViewModel> GetAll();
        CategoryViewModel Get(int id);
        bool Add(CategoryAddViewModel categoryAddViewModel);
        bool Update(CategoryUpdateViewModel categoryUpdateVeiewModel);
        bool Delete(int id);
    }
}
