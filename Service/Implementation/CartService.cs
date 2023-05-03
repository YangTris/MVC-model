using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class CartService : ICartService
    {
        private ApplicationDbContext _context;
        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsSync(CartItem cart)
        {
            _context.Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsSync(int id)
        {
            var cart = GetById(id);
            if (cart != null)
            {
                _context.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<CartItem> GetAll()
        {
            return _context.CartItems.ToList();
        }

        public CartItem GetById(int id)
        {
            return _context.CartItems.Where(x => x.cartID == id).FirstOrDefault();
        }

        public async Task UpdateAsSync(CartItem cart)
        {
            _context.CartItems.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var cart = GetById(id);
            _context.CartItems.Update(cart);
            await _context.SaveChangesAsync();
        }
    }
}
