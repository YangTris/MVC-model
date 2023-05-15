using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class PaymentService : IPaymentService
    {
        private ApplicationDbContext _context;
        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsSync(Payment payment)
        {
            _context.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsSync(string id)
        {
            var payment = GetById(id);
            if (payment != null)
            {
                _context.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Payment> GetAll()
        {
            return _context.Payment.ToList();
        }

        public Payment GetById(string id)
        {
            return _context.Payment.Where(x => x.paymentID.Equals(id)).FirstOrDefault();
        }

        public async Task UpdateAsSync(Payment payment)
        {
            _context.Payment.Update(payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(string id)
        {
            var payment = GetById(id);
            _context.Payment.Update(payment);
            await _context.SaveChangesAsync();
        }
        public Payment GetByUserID(string userId)
        {
            return _context.Payment.Where(x => x.userID.Equals(userId)).FirstOrDefault();
        }
    }
}
