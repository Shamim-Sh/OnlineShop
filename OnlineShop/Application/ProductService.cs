using OnlineShop.Models;
using OnlineShop.Persistence;
using OnlineShop.ViewModels;
using System.Collections.Generic;

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
            product.Name = productAddViewModel.Name;
            product.Description = productAddViewModel.Description;
            product.Stock = productAddViewModel.Stock;
            product.Price = productAddViewModel.Price;
            _repository.Add(product);
            
        }
        public List<ProductViewModel> GetAll()
        {
            List<ProductViewModel> viewModels = new List<ProductViewModel>();
            List<Product> products = _repository.GetAll();
            foreach (var product in products)
            {
                ProductViewModel viewModel = new ProductViewModel();
                viewModel.Name = product.Name;
                viewModel.Description = product.Description;
                viewModel.Stock = product.Stock;
                viewModel.Price = product.Price;
                viewModel.ImageUrl = product.ImageUrl;
                viewModels.Add(viewModel);
            }
            return viewModels;
        }
    }
}
