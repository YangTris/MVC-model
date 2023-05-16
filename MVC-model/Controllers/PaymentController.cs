using Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_model.Models;
using Service;
using Service.Implementation;
using System.Security.Claims;

namespace MVC_model.Controllers
{
    public class PaymentController : Controller
    {
        private IPaymentService _paymentService;
        private IWebHostEnvironment _webHostEnvironment;
        private IItemService _itemService;
        private IProductService _productService;
        public PaymentController(IPaymentService paymentService, IWebHostEnvironment webHostEnvironment, IItemService itemService, IProductService productService)
        {
            _paymentService = paymentService;
            _webHostEnvironment = webHostEnvironment;
            _itemService = itemService;
            _productService = productService;
        }

        /*[HttpGet]
        public IActionResult Index()
        {
            var model = _paymentService.GetAll().Select(payment => new IndexPaymentViewModel
            {
                paymentID = payment.paymentID,
                userID = payment.userID,
                method = payment.method,
                nameOnCard = payment.nameOnCard,
                cardNumber = payment.cardNumber,
                expiration = payment.expiration,
                CVV = payment.CVV,
            }).ToList();
            return View(model);
        }*/
        [HttpGet]
        public IActionResult Index()
        {
            var model = _paymentService.GetAll().Select(payment => new TransactionViewModel
            {
                paymentID = payment.paymentID,
                firstName = payment.firstName,
                lastName = payment.lastName,
                phoneNumber= payment.phone,
                totalPrice= payment.totalPrice,
                method = payment.method,
                nameOnCard = payment.nameOnCard,
                cardNumber = payment.cardNumber,
                expiration = payment.expiration,
                CVV = payment.CVV,
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var user = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = new TransactionViewModel
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var payment = new Payment
                {
                    paymentID = model.paymentID,
                    userID = model.userID,
                    firstName = model.firstName,
                    lastName = model.lastName,
                    email = model.email,
                    address = model.address,
                    phone = model.phoneNumber,
                    method = model.method,
                    nameOnCard = model.nameOnCard,
                    cardNumber = model.cardNumber,
                    expiration = model.expiration,
                    CVV = model.CVV,
                    totalPrice = model.totalPrice,
                };              
                await _paymentService.CreateAsSync(payment);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            var payment = _paymentService.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }
            var model = new DetailTransactionViewModel
            {
                paymentID = payment.paymentID,
                userID = payment.userID,
                firstName = payment.firstName,
                lastName = payment.lastName,
                email = payment.email,
                address = payment.address,
                phoneNumber = payment.phone,
                method = payment.method,
                nameOnCard = payment.nameOnCard,
                cardNumber = payment.cardNumber,
                expiration = payment.expiration,
                CVV = payment.CVV,
                totalPrice = payment.totalPrice,
            };
            return View(model);
        }
    }
}
