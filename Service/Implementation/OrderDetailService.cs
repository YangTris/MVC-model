using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class OrderDetailService : IOrderDetailService
    {
        private ApplicationDbContext _context;
        public OrderDetailService(ApplicationDbContext context)
        {
            _context = context;
        }
        public OrderDetail GetById(int id)
        {
            return _context.OrderDetail.Where(x => x.OrderDetailId == id).FirstOrDefault();
        }

        public async Task CreateAsSync(OrderDetail order)
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

        public IEnumerable<OrderDetail> GetAll()
        {
            return _context.OrderDetail.ToList();
        }

        public async Task UpdateAsSync(OrderDetail order)
        {
            _context.OrderDetail.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var order = GetById(id);
            _context.OrderDetail.Update(order);
            await _context.SaveChangesAsync();
        }

        /*public IEnumerable<OrderDetail> GetByOrderId(int id)
        {
            return _context.OrderDetail.Where(x=>x.orderID==id).ToList();
        }*/
    }
}
