using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductAddViewModel productAddViewModel)
        {
            _productService.Add(productAddViewModel);
            return View();
        }


    }
}
