using OnlineShop.Models;
using OnlineShop.Persistence;
using OnlineShop.ViewModels;

namespace OnlineShop.Application
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;
        public ProductService(IProductRepository productRepository)
        {
            _repository = productRepository;
        }
        public void Add(ProductAddViewModel productAddViewModel)
        {
            Product product = new Product();
            _repository.Add(product);
            
        }
    }
}
