using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_model.Models;
using Service;

namespace MVC_model.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IPaymentService _paymentService;
        private readonly IProductService _productService;

        public TransactionController(ICartService cartService, IPaymentService paymentService, IProductService productService)
        {
            _cartService = cartService;
            _paymentService = paymentService;
            _productService = productService;
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
                    method = model.method,
                    nameOnCard = model.nameOnCard,
                    cardNumber = model.cardNumber,
                    expiration = model.expiration,
                    CVV = model.CVV,
                    ItemId = model.CartId,
                    CartId = model.CartId,
                    Quantity = model.Quantity,
                    DateCreated = model.DateCreated,
                    ProductId = model.ProductId,
                };
            }
            return View(model);
        }
    }
}
