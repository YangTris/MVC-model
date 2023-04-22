using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Task CreateAsSync(Product product);
        Task UpdateAsSync(Product product);
        Task UpdateById(int id);
        Task DeleteAsSync(int id);
    }
}
