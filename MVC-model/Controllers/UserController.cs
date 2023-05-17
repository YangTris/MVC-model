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
        /*public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CategorySortParm = String.IsNullOrEmpty(sortOrder) ? "category_desc" : "";
            var product = from s in db.Produt
                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.productName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    product = product.OrderByDescending(s => s.productName);
                    break;
                case "category_desc":
                    product = product.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    product = product.OrderBy(s => s.productName);
                    break;
            }

            return View(product.ToList());
        }*/


        private IItemService _itemService;
        private IProductService _productService;
        private IWebHostEnvironment _webHostEnvironment;
        private IPaymentService _paymentService;
        public UserController(IProductService productService, IItemService itemService, IWebHostEnvironment webHostEnvironment, IPaymentService paymentService)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
            _itemService = itemService;
            _paymentService = paymentService;

        }

        [HttpGet]
        public IActionResult CartItem()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = new UserCartIndex
            {
                paymentID = Guid.NewGuid().ToString(),
                userID = user,
                listItem = _itemService.getUserItem(user),
                totalPrice = totalPriceCal(_itemService.getUserItem(user)),
            };
            return View(model);
        }

        public double totalPriceCal(IEnumerable<Item> listItem)
        {
            double totalPrice = 0;
            foreach (Item item in listItem)
            {
                totalPrice += _productService.GetById(item.productID).price * item.quantity;
            }
            return totalPrice;
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
