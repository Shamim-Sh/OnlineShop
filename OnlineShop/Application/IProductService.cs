using OnlineShop.ViewModels;

namespace OnlineShop.Application
{
    public interface IProductService
    {
        void Add(ProductAddViewModel productAddViewModel);
        List<ProductViewModel> GetAll();
        bool Delete(int id);
        bool Update(ProductUpdateViewModel viewModel);
    }
}
