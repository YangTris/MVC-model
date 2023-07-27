/*using DataAccess.Migrations;*/
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_model.Models;
using Newtonsoft.Json;
using Service;
using System.Security.Claims;
using PagedList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace MVC_model.Controllers
{
    
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IWebHostEnvironment _webHostEnvironment;
        private IItemService _itemService;

        public ProductController(IProductService productService, IWebHostEnvironment webHostEnvironment, IItemService itemService)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
            _itemService = itemService;
        }
        /*public ViewResult Paging(int? page)
        {

        }
*/
        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll().Select(product => new IndexProductViewModel
            {
                productID = product.productID,
                productName = product.productName,
                brand = product.brand,
                price = product.price,
                category = product.category,
                imgURL = product.imgURL,
                discountPercentage = product.discountPercentage,
                /*created_at = product.created_at,
                modified_at = product.modified_at,
                deleted_at = product.deleted_at,
                create_by = product.create_by,*/
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Product()
        {
            var model = _productService.GetAll().Select(product => new IndexProductViewModel
            {
                productID = product.productID,
                productName = product.productName,
                brand = product.brand,
                price = product.price,
                category = product.category,
                imgURL = product.imgURL,
                discountPercentage = product.discountPercentage,
                /*created_at = product.created_at,
                modified_at = product.modified_at,
                deleted_at = product.deleted_at,
                create_by = product.create_by,*/
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
                    productName = model.productName,
                    brand = model.brand,
                    price = model.price,
                    category = model.category,
                    discountPercentage =model.discountPercentage,
                    /*created_at = model.created_at,
                    modified_at = model.modified_at,
                    deleted_at = model.deleted_at,
                    create_by = model.create_by,*/
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
                name = product.productName,
                brand = product.brand,
                price = product.price,
                category = product.category,
                imgURL = product.imgURL,
                discountPercentage = product.discountPercentage,
                /*created_at = product.created_at,
                modified_at = product.modified_at,
                deleted_at = product.deleted_at,
                create_by = product.create_by,*/
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult AddToCart(int id)
        {
            var productTemp = _productService.GetById(id);
            if (productTemp == null)
            {
                return NotFound();
            }
            /*bool isAuthenticated = User.Identity.IsAuthenticated;
            if (!isAuthenticated)
            {
                
                return NotFound();
            }*/
            var user = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = new CartIndexProductViewModel
            {
                itemID = Guid.NewGuid().ToString(),
                productID = productTemp.productID,
                quantity = 1,
                userID = user,
                productName = productTemp.productName,
                discountPercentage = productTemp.discountPercentage,
                brand = productTemp.brand,
                imgURL = productTemp.imgURL,
                category = productTemp.category,
                price = productTemp.price,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(CartIndexProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(_itemService.CheckItem(model.userID,model.productID) == true)
                {
                    Item item = new Item
                    {
                        itemID = model.itemID,
                        productID = model.productID,
                        quantity = model.quantity,
                        userID=model.userID,
                        productName = model.productName,
                        productPrice = model.price,
                    };
                    await _itemService.CreateAsSync(item);
                }
                return RedirectToAction("Product");
            }       
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new DeleteProductViewModel
            {
                productID = product.productID,
                productName = product.productName,
                
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _productService.DeleteAsSync(model.productID);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new EditProductViewModel
            {
                productID = product.productID,
                productName = product.productName,
                brand = product.brand,
                price = product.price,
                category = product.category,
                discountPercentage = product.discountPercentage,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (EditProductViewModel model)
        {
            var product= _productService.GetById(model.productID);
            if(product== null)
            {
                return NotFound();
            }
            product.productID = model.productID;
            product.productName = model.productName;
            product.brand = model.brand;
            product.price = model.price;
            product.category = model.category;
            product.discountPercentage = model.discountPercentage;
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
            return View(model);
        }



    }
}
