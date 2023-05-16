using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class ItemService:IItemService
    {
        private ApplicationDbContext _context;
        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task CreateAsSync(Item item)
        {
            _context.Add(item);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteAsSync(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public Item GetById(int id)
        {
            return _context.Item.Where(x => x.itemID.Equals(id)).FirstOrDefault();
        }

        public async Task UpdateAsSync(Item item)
        {
            _context.Item.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var item = GetById(id);
            _context.Item.Update(item);
            await _context.SaveChangesAsync();
        }

        /*public IEnumerable<Item> GetCart(int id) => _context.Item
                .Where(a => a.cartID == id)
                .ToList();*/
        public bool CheckItem(string userID, int productID)
        {
            var item = _context.Item.SingleOrDefault(c => c.userID == userID && c.product.productID == productID);
            if (item == null) return true;
            item.quantity++;
            UpdateAsSync(item);
            return false;
        }

        public IEnumerable<Item> getUserItem(string userID)
        {
            IEnumerable<Item> check = _context.Item.Where(x => x.userID == userID).ToList();
            if(check == null) return Enumerable.Empty<Item>();
            return check;
        }
    }
}
