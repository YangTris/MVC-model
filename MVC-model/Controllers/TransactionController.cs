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
        private readonly ICartService _cartService;
        private readonly IPaymentService _paymentService;
        private readonly IProductService _productService;
        private readonly UserManager<IdentityUser> userManager;

        public TransactionController(ICartService cartService, IPaymentService paymentService, IProductService productService, UserManager<IdentityUser> userManager)
        {
            _cartService = cartService;
            _paymentService = paymentService;
            _productService = productService;
            this.userManager = userManager;
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
                var user = await userManager.GetUserAsync(User);
                var transaction = new Transaction
                {
                    userID = user.Id,
                    firstName = model.firstName, 
                    lastName = model.lastName,
                    /*userName = user.UserName,*/
                    email = user.Email,
                    address = model.address,
                
                    /*ItemId = model.CartId,
                    CartId = model.CartId,
                    Quantity = model.Quantity,
                    DateCreated = model.DateCreated,
                    ProductId = model.ProductId,*/
                };
                var payment = new Payment
                {
                    method = model.method,
                    nameOnCard = model.nameOnCard,
                    cardNumber = model.cardNumber,
                    expiration = model.expiration,
                    CVV = model.CVV,
                };
            }
            return View(model);
        }
    }
}
