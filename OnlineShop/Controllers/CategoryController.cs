using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application;
using OnlineShop.ViewModels;
using System.Collections.Generic;

namespace OnlineShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            List<CategoryViewModel> categories = _categoryService.GetAll();
            return View(categories);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryAddViewModel categoryAddViewModel)
        {
            var result = _categoryService.Add(categoryAddViewModel);

            return result ? RedirectToAction("Index") : BadRequest();
        }

        public IActionResult Edit(int id)
        {
            CategoryViewModel category = _categoryService.Get(id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(CategoryUpdateViewModel viewModel)
        {
            var result = _categoryService.Update(viewModel);

            return result ? RedirectToAction("Index") : BadRequest();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);

            return result ? RedirectToAction("Index") : BadRequest();
        }
    }
}