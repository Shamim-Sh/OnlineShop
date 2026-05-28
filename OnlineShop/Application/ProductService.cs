using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Models;
using OnlineShop.Persistence;
using OnlineShop.ViewModels;
using System.Collections.Generic;

namespace OnlineShop.Application
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;
        private ICategoryService _categoryService;
        public ProductService(IProductRepository productRepository, ICategoryService categoryService)
        {
            _repository = productRepository;
            _categoryService = categoryService;
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
                viewModel.Id = product.Id;
                viewModel.Category = product.Category?.Name;
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        public ProductViewModel Get(int id)
        {
            Product? product = _repository.Get(id);

            if (product == null)
                return null;

            ProductViewModel viewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                ImageUrl = product.ImageUrl,
                CategoryId = product.Category?.Id,
                Categories = _categoryService.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
            };

            return viewModel;
        }

        public bool Add(ProductAddViewModel productAddViewModel)
        {
            var product = new Product();
            product.Name = productAddViewModel.Name;
            product.Description = productAddViewModel.Description;
            product.Stock = productAddViewModel.Stock;
            product.Price = productAddViewModel.Price;
            product.CategoryId = productAddViewModel.CategoryId;
            var rowAffected = _repository.Add(product);

            if (rowAffected > 0)
                return true;
            else return false;
        }

        public bool Update(ProductUpdateViewModel viewModel)
        {
            var product = _repository.Get(viewModel.Id);
            if (product is null) return false;

            product.Name = viewModel.Name;
            product.Description = viewModel.Description;
            product.Stock = viewModel.Stock;
            product.Price = viewModel.Price;
            product.CategoryId = viewModel.CategoryId;

            var rowAffected = _repository.Update(product);

            if (rowAffected > 0)
                return true;
            else return false;
        }

        public bool Delete(int id)
        {
            var product = _repository.Get(id);

            if (product is null) return false;

            var rowAffected = _repository.Delete(product);

            if (rowAffected > 0)
                return true;
            else return false;
        }

        public ProductAddViewModel GetWithCategory(ProductAddViewModel? viewModel= null)
        {
            var categories = _categoryService.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });
            if (viewModel == null)
            {
                viewModel = new ProductAddViewModel
                {
                    Categories = categories
                };
            }
            else
            {
                viewModel.Categories = categories;

            }
            return viewModel;
        }
    }
}
