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
        Order GetById(int id);
        Task CreateAsSync(Order order);
        Task UpdateAsSync(Order order);
        Task UpdateById(int id);
        Task DeleteAsSync(int id);
        decimal Total(List<OrderDetail> orderDetails);
    }
}
