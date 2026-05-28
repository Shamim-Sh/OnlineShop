using OnlineShop.Models;
using OnlineShop.Persistence;
using OnlineShop.ViewModels;
using System.Collections.Generic;

namespace OnlineShop.Application
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }

        public List<CategoryViewModel> GetAll()
        {
            List<CategoryViewModel> viewModels = new List<CategoryViewModel>();
            List<Category> categories = _repository.GetAll();

            foreach (var category in categories)
            {
                CategoryViewModel viewModel = new CategoryViewModel();
                viewModel.Id = category.Id;
                viewModel.Name = category.Name;
                viewModels.Add(viewModel);
            }

            return viewModels;
        }

        public CategoryViewModel Get(int id)
        {
            Category category = _repository.Get(id);

            if (category == null)
                return null;

            CategoryViewModel viewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };

            return viewModel;
        }

        public bool Add(CategoryAddViewModel categoryAddViewModel)
        {
            var category = new Category();
            category.Name = categoryAddViewModel.Name;

            var rowAffected = _repository.Add(category);

            if (rowAffected > 0)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            var category = _repository.Get(id);

            if (category is null) return false;

            var rowAffected = _repository.Delete(category);

            if (rowAffected > 0)
                return true;
            else
                return false;
        }

        public bool Update(CategoryUpdateViewModel viewModel)
        {
            var category = _repository.Get(viewModel.Id);

            if (category is null) return false;

            category.Name = viewModel.Name;

            var rowAffected = _repository.Update(category);

            if (rowAffected > 0)
                return true;
            else
                return false;
        }
    }
}
