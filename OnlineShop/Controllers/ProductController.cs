using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Application;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            List<ProductViewModel> products = _productService.GetAll();
            return View(products);
        }

        public IActionResult Add()
        {
            ProductAddViewModel viewmodel = _productService.GetWithCategory();
            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult Add(ProductAddViewModel productAddViewModel)
        {
            if (!ModelState.IsValid)
            {
                ProductAddViewModel viewModel = _productService.GetWithCategory(productAddViewModel);
                return View(viewModel);
            }

            var result = _productService.Add(productAddViewModel);
            return result ? RedirectToAction("Index") : BadRequest();
        }

        public IActionResult Edit(int id)
        {
            var product = _productService.Get(id);
            if (product == null)
                return NotFound();

              return View(product);
        }


        [HttpPost]
        public IActionResult Edit(ProductUpdateViewModel viewModel)
        {
                  var result = _productService.Update(viewModel);
            return result ? RedirectToAction("Index") : BadRequest();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            return result ? RedirectToAction("Index") : BadRequest();
        }
    }
}
