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
            _productService.Add(productAddViewModel);
            return View();
        }

        [HttpPut]
        public IActionResult Update(ProductUpdateViewModel viewModel)
        {
            var result = _productService.Update(viewModel);
            if (result == true)
                return Redirect("/Index");
            else
                return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            if (result == true)
                return Redirect("/Index");
            else
                return BadRequest();

        }


    }
}
