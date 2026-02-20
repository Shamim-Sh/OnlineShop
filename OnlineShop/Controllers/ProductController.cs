using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Add()
        {
            _productService.Add();
            return View();
        }

    }
}
