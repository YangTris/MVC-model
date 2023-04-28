using Entity;
using Microsoft.AspNetCore.Mvc;
using MVC_model.Models;
using Service;

namespace MVC_model.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _orderService.GetAll().Select(order => new IndexOrderViewModel
            {
                orderID = order.orderID,
                userName = order.userName,
                created_date = order.created_date,
                status = order.status,
                total = order.total,
                confirmed_by = order.confirmed_by,
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateOrderViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    orderID = model.orderID,
                    userName = model.userName,
                    created_date = model.created_date,
                    status = model.status,
                    total = model.total,
                    confirmed_by = model.confirmed_by,
                };
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var order = _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            var model = new DetailOrderViewModel
            {
                orderID = order.orderID,
                userName = order.userName,
                created_date = order.created_date,
                status = order.status,
                total = order.total,
                confirmed_by = order.confirmed_by,
            };
            return View(model);
        }
    }
}
