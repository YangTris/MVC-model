﻿using Entity;
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
        private IOrderService _orderService;
        public PaymentController(
            IPaymentService paymentService,
            IWebHostEnvironment webHostEnvironment, 
            IItemService itemService, 
            IProductService productService,
            IOrderService orderService)
        {
            _paymentService = paymentService;
            _webHostEnvironment = webHostEnvironment;
            _itemService = itemService;
            _productService = productService;
            _orderService = orderService;
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
                //firstName = payment.firstName,
                //lastName = payment.lastName,
                //phoneNumber= payment.phone,
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
                    method = model.method,
                    nameOnCard = model.nameOnCard,
                    cardNumber = model.cardNumber,
                    expiration = model.expiration,
                    CVV = model.CVV,
                    totalPrice = model.totalPrice,
                }; 
                var order = new Order
                {
                    FirstName = model.firstName,
                    LastName = model.lastName,
                    Email = model.email,
                    Address = model.address,
                    Phone = model.phoneNumber,
                    paymentID = model.paymentID,
                    listItem = _itemService.getUserItem(model.userID),
                    Total = model.totalPrice,
                };
                await _paymentService.CreateAsSync(payment);
                await _orderService.CreateAsSync(order);
                await _itemService.DeleteUserItem(model.userID);
                return RedirectToAction("Product","Product");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Detail(string id)
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
                //firstName = payment.firstName,
                //lastName = payment.lastName,
                //email = payment.email,
                //address = payment.address,
                //phoneNumber = payment.phone,
                method = payment.method,
                nameOnCard = payment.nameOnCard,
                cardNumber = payment.cardNumber,
                expiration = payment.expiration,
                CVV = payment.CVV,
                totalPrice = payment.totalPrice,
                listItem = _itemService.getUserItem(payment.userID),
            };
            return View(model);
        }
    }
}
