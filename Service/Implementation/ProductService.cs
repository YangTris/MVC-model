using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsSync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsSync(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.product.ToList();
        }

        public Product GetById(int id)
        {
            return _context.product.Where(x => x.productID == id).FirstOrDefault();
        }

        public async Task UpdateAsSync(Product product)
        {
            _context.product.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var product = GetById(id);
            _context.product.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
