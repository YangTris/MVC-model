using Entity;
using Microsoft.AspNetCore.Mvc;
using MVC_model.Models;
using Service;

namespace MVC_model.Controllers
{
    public class PaymentController : Controller
    {
        private IPaymentService _paymentService;
        private IWebHostEnvironment _webHostEnvironment;
        public PaymentController(IPaymentService paymentService, IWebHostEnvironment webHostEnvironment)
        {
            _paymentService = paymentService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
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
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreatePaymentViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var payment = new Payment
                {
                    paymentID = model.paymentID,
                    userID = model.userID,
                    method = model.method,
                    nameOnCard = model.nameOnCard,
                    cardNumber = model.cardNumber,
                    expiration = model.expiration,
                    CVV = model.CVV,
                };              
                await _paymentService.CreateAsSync(payment);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var payment = _paymentService.GetById(id);
            if (payment == null)
            {
                return NotFound();
            }
            var model = new DetailPaymentViewModel
            {
                paymentID = payment.paymentID,
                userID = payment.userID,
                method = payment.method,
                nameOnCard = payment.nameOnCard,
                cardNumber = payment.cardNumber,
                expiration = payment.expiration,
                CVV = payment.CVV,
            };
            return View(model);
        }
    }
}
