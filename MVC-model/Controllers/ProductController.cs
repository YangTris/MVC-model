using Microsoft.AspNetCore.Mvc;
using MVC_model.Models;
using Service;

namespace MVC_model.Controllers
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
            var model = _productService.GetAll().Select(product => new IndexProductViewModel
            {
                productID = product.productID,
                name = product.name,
                brand = product.brand,
                description = product.description,
                price = product.price,
                quantity = product.quantity,
                imgURL = product.imgURL,
                inDate = product.inDate,
            }).ToList();
            return View(model);
        }
    }
}
