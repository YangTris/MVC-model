using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order GetById(string id);
        Task CreateAsSync(Order order);
        Task UpdateAsSync(Order order);
        Task UpdateById(string id);
        Task DeleteAsSync(string id);
    }
}
