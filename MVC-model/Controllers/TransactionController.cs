using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_model.Models;
using Service;

namespace MVC_model.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IProductService _productService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ICartService _cartService;
        private readonly IItemService _itemService;

        public TransactionController(IPaymentService paymentService, IProductService productService, UserManager<IdentityUser> userManager, ICartService cartService, IItemService itemService)
        {
            _paymentService = paymentService;
            _productService = productService;
            this.userManager = userManager;
            _cartService = cartService;
            _itemService = itemService; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new TransactionViewModel { };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var transaction = new Transaction
                {
                    firstName = model.firstName,
                    lastName = model.lastName,
                    userID = model.userID,
                    email = model.email,
                    address = model.address,
                    paymentID = _paymentService.GetByUserID(model.userID).paymentID,
                    method = _paymentService.GetByUserID(model.userID).method,
                    nameOnCard = _paymentService.GetByUserID(model.userID).nameOnCard,
                    cardNumber = _paymentService.GetByUserID(model.userID).cardNumber,
                    expiration = _paymentService.GetByUserID(model.userID).expiration,
                    CVV = _paymentService.GetByUserID(model.userID).CVV,
                    CartId = _cartService.GetByUserId(model.userID).shoppingCartID,
                    items = _itemService.GetCart(_cartService.GetByUserId(model.userID).shoppingCartID),
                };
                
            }
            return View(model);
        }
    }
}
