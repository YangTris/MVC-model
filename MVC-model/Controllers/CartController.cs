using Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_model.Models;
using Service;
using System.Security.Claims;

namespace MVC_model.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private IItemService _itemService;
        private IProductService _productService;
        private IWebHostEnvironment _webHostEnvironment;
        public CartController(ICartService cartService, IItemService itemService, IWebHostEnvironment webHostEnvironment)
        {
            _cartService = cartService;
            _itemService = itemService;
            _webHostEnvironment = webHostEnvironment;
        }
       /* [HttpGet]
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
        public IActionResult Create()
        {
            var model = new CreateCartViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCartViewModel model)
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
        }
        /*[HttpGet]
        public IActionResult AddToCart(int id)
        {
            //get cart id

            var model = new CreateCartViewModel
            {
                itemID = model.itemID,
                productID = productId,

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(DeleteProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _productService.DeleteAsSync(model.productID);
                return RedirectToAction("Index");
            }
            return View(model);
        }*/
    }
}
