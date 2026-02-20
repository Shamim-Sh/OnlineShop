using OnlineShop.ViewModels;

namespace OnlineShop.Application
{
    public interface IProductService
    {
        void Add(ProductAddViewModel productAddViewModel);
        public List<ProductViewModel> GetAll();

    }
}
