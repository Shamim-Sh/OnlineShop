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
            List<ProductViewModel> products = _productService.GetAll();
            //var products1 = _productService.GetAll();

            return View(products);
        }

        public IActionResult Edit(int id)
        {

            ProductViewModel product = _productService.Get(id);

            return View(product);

        }


        /// <summary>
        /// This method calls when user clicks on Add action
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            return View();
        }


        /// <summary>
        /// This method calls after submit
        /// </summary>
        /// <param name="productAddViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(ProductAddViewModel productAddViewModel)
        {
            var result = _productService.Add(productAddViewModel);
            if (result == true)
                return Redirect("/Product");
            else
                return BadRequest();
        }

        [HttpPost]
        public IActionResult Edit(ProductUpdateViewModel viewModel)
        {
            var result = _productService.Update(viewModel);
            if (result == true)
                return Redirect("/Product");
            else
                return BadRequest();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            if (result == true)
                return Redirect("/Product");
            else
                return BadRequest();

        }


    }
}
