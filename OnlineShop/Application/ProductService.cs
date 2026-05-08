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

        #region CRUD     
        public void Add(ProductAddViewModel productAddViewModel)
        {
            var product = new Product();
            product.Name = productAddViewModel.Name;
            product.Description = productAddViewModel.Description;
            product.Stock = productAddViewModel.Stock;
            product.Price = productAddViewModel.Price;
            _repository.Add(product);

        }

        public bool Delete(int id)
        {
            var product = _repository.Get(id);

            if (product is null) return false;

            _repository.Delete(product);

            return true;
        }
        #endregion

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
                viewModel.Id = product.Id;
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        public bool Update(ProductUpdateViewModel viewModel)
        {
            var product = _repository.Get(viewModel.Id);
            if (product is null) return false;

            product.Name = viewModel.Name;
            product.Description = viewModel.Description;
            product.Stock = viewModel.Stock;
            product.Price = viewModel.Price;

            var rowAffected = _repository.Update(product);

            if (rowAffected > 0)
                return true;
            else return false;

            // return rowAffected > 0;
        }
    }
}
