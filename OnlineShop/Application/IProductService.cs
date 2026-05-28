using OnlineShop.ViewModels;

namespace OnlineShop.Application
{
    public interface IProductService
    {
        List<ProductViewModel> GetAll();
        ProductViewModel? Get(int id);
        ProductAddViewModel GetWithCategory(ProductAddViewModel? viewModel = null);
        bool Add(ProductAddViewModel productAddViewModel);
        bool Update(ProductUpdateViewModel productUpdateViewModel);
        bool Delete(int id);
    }
}
