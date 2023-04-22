using Entity;
using Microsoft.AspNetCore.Mvc;
using MVC_model.Models;
using Service;

namespace MVC_model.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
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
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateProductViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product 
                { 
                    productID=model.productID,
                    name = model.name,
                    brand = model.brand,
                    description = model.description,
                    price = model.price,
                    quantity = model.quantity,
                    inDate = model.inDate,
                };
                if (model.imgURL != null && model.imgURL.Length > 0)
                {

                    var uploadDir = @"images/products";
                    var fileName = Path.GetFileNameWithoutExtension(model.imgURL.FileName);
                    var extension = Path.GetExtension(model.imgURL.FileName);
                    var webRootPath = _webHostEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.imgURL.CopyToAsync(new FileStream(path, FileMode.Create));
                    product.imgURL = "/" + uploadDir + "/" + fileName;
                    await _productService.CreateAsSync(product);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new DetailProductViewModel
            {
                productID = product.productID,
                name = product.name,
                brand = product.brand,
                description = product.description,
                price = product.price,
                quantity = product.quantity,
                imgURL = product.imgURL,
                inDate = product.inDate,
            };
            return View(model);
        }
    }
}
