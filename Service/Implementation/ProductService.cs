using DataAccess;
using Entity;
using Microsoft.EntityFrameworkCore;
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
            return _context.Product.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Product.Where(x => x.productID == id).FirstOrDefault();
        }

        public async Task UpdateAsSync(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(int id)
        {
            var product = GetById(id);
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> Search(string sortOrder, string currentFilter, int? pageNumber, string searchString)
        {
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Product> query = _context.Product;

            /*if (!string.IsNullOrEmpty(searchString) && string.IsNullOrEmpty(nhomId.ToString()))
            {
                query = query.Where(e => e.TEN_THUATNGU.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(nhomId.ToString()) && searchString == null)
            {
                query = query.Where(e => e.NHOM_ID == nhomId);
            }

            if (!string.IsNullOrEmpty(nhomId.ToString()) && !string.IsNullOrEmpty(searchString))
            {
                query = query.Where(e => e.NHOM_ID == nhomId && e.TEN_THUATNGU.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.TEN_THUATNGU.Contains(searchString));
            }*/
            if (!String.IsNullOrEmpty(searchString))
            {
                query=query.Where(e=> e.productName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    query = query.OrderByDescending(x => x.price);
                    break;
                case "ID_desc":
                    query = query.OrderByDescending(x => x.productID);
                    break;
                case "name_desc":
                    query = query.OrderByDescending(x => x.productName);
                    break;
                case "ID_asc":
                    query = query.OrderBy(s => s.productID);
                    break;
                case "name_asc":
                    query = query.OrderBy(s => s.productName);
                    break;
                case "price_asc":
                    query=query.OrderBy(s=> s.price);
                    break;
                default:
                    query = query.OrderByDescending(s => s.productID);
                    break;
            }

            return await query
/*                .Include("NHOM")
                .Include("TIEUNHOM")*/
                .ToListAsync();
        }

        
    }
}
