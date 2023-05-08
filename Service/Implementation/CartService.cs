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

        public Task CreateAsSync(ShoppingCart cart)
        {
            _context.Add(cart);
            return _context.SaveChangesAsync();
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

        public ShoppingCart GetById(int id)
        {
            return _context.ShoppingCart.Where(x => x.shoppingCartID == id).FirstOrDefault();
        }

        public async Task UpdateAsSync(ShoppingCart cart)
        {
            _context.ShoppingCart.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var cart = GetById(id);
            _context.ShoppingCart.Update(cart);
            await _context.SaveChangesAsync();
        }
        public ShoppingCart GetByUserId(string id)
        {
            return _context.ShoppingCart.Where(x => x.userID.Equals(id)).FirstOrDefault();
        }
    }
}
