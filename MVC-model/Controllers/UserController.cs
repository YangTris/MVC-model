using Entity;
using Microsoft.AspNetCore.Mvc;
using MVC_model.Models;
using Newtonsoft.Json;
using Service;
using Service.Implementation;
using System.Globalization;
using System.Security.Claims;

namespace MVC_model.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        private ICartService _cartService;
        private IItemService _itemService;
        private IProductService _productService;
        private IWebHostEnvironment _webHostEnvironment;
        public UserController(IProductService productService, ICartService cartService, IItemService itemService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
            _cartService = cartService;
            _itemService = itemService;
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

        /*[HttpGet]
        public IActionResult Index()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = _itemService.GetCart(_cartService.GetByUserId(user).shoppingCartID).Select(cartItem => new IndexCartViewModel
            {
                itemID = cartItem.cartID,
                productID = cartItem.product.productID,
                productName = cartItem.product.productName,
                brand = cartItem.product.brand,
                price = cartItem.product.price,
                Quantity = cartItem.quantity
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddtoCart()
        {
            var model = new CreateCartViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddtoCart(CreateCartViewModel model)
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid)
            {
                var item = new Item
                {
                    itemID = model.itemID,
                    product = _productService.GetById(model.productID),
                    quantity = model.quantity,
                    cartID = _cartService.GetByUserId(user).shoppingCartID,
                };
                await _itemService.CreateAsSync(item);
                return RedirectToAction("Index");
            }
            return View();
        }*/

        [HttpGet]
        public IActionResult AddToCart(int id)
        {
            var productTemp = _productService.GetById(id);
            if (productTemp == null)
            {
                return NotFound();
            }
            var user = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = new IndexProductViewModel
            {
                itemID = Guid.NewGuid().ToString(),
                productID = id,
                quantity = 1,
                userID = user,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(IndexProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_itemService.CheckItem(model.userID, model.productID) == true)
                {
                    Item item = new Item
                    {
                        itemID = model.itemID,
                        product = _productService.GetById(model.productID),
                        quantity = model.quantity,
                        userID = model.userID,
                    };
                    await _itemService.CreateAsSync(item);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
