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

        public const string CARTKEY = "cart";
        List<CartItem> GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }
        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }

        [Route("addcart/{productid:int}", Name = "addcart")]
        public IActionResult AddToCart([FromRoute] int productid)
        {

            var product = _productService.GetById(productid);
            if (product == null)
                return NotFound("Không có sản phẩm");

            // Xử lý đưa vào Cart ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.productID == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.quantity++;
            }
            else
            {
                //  Thêm mới
                cart.Add(new CartItem() { quantity = 1, product = product });
            }

            // Lưu cart vào Session
            SaveCartSession(cart);
            // Chuyển đến trang hiện thị Cart
            return RedirectToAction(nameof(Cart));
        }

        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }

        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart([FromForm] int productid, [FromForm] int quantity)
        {
            // Cập nhật Cart thay đổi số lượng quantity ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.productID == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.quantity = quantity;
            }
            SaveCartSession(cart);
            // Trả về mã thành công (không có nội dung gì - chỉ để Ajax gọi)
            return Ok();
        }
        [Route("/removecart/{productid:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int productid)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.productID == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cart.Remove(cartitem);
            }

            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }
    }
}
