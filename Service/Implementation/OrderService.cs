using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class OrderService : IOrderService
    {
        private decimal total;
        private ApplicationDbContext _context;
        private ProductService productService;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsSync(Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsSync(int id)
        {
            var order = GetById(id);
            if (order != null)
            {
                _context.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Order.ToList();
        }

        public Order GetById(int id)
        {
            return _context.Order.Where(x => x.orderID == id).FirstOrDefault();
        }

        public async Task UpdateAsSync(Order order)
        {
            _context.Order.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var order = GetById(id);
            _context.Order.Update(order);
            await _context.SaveChangesAsync();
        }

        public decimal Total(List<OrderDetail> orderDetails)
        {
            double sum = 0;
            foreach (OrderDetail detail in orderDetails)
            {
                sum += productService.GetById(detail.productID).price * detail.Quantity;
            }
            return (decimal)sum;
        }
    }
}
