using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICartService
    {
        IEnumerable<CartItem> GetAll();
        CartItem GetById(int id);
        Task CreateAsSync(CartItem cart);
        Task UpdateAsSync(CartItem cart);
        Task UpdateById(int id);
        Task DeleteAsSync(int id);
    }
}
