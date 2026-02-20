using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Application;
using OnlineShop.Models;
using OnlineShop.ViewModels;
using System.Diagnostics;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            List<ProductViewModel> products = _productService.GetAll();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
