using OnlineShop.ViewModels;

namespace OnlineShop.Application
{
    public interface IProductService
    {
        bool Add(ProductAddViewModel productAddViewModel);
        List<ProductViewModel> GetAll();
        bool Delete(int id);
        bool Update(ProductUpdateViewModel viewModel);
        ProductViewModel Get(int id);
    }
}
