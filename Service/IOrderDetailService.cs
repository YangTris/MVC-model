using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetAll();
        OrderDetail GetById(int id);
        //IEnumerable<OrderDetail> GetByOrderId(int id);
        Task CreateAsSync(OrderDetail order);
        Task UpdateAsSync(OrderDetail order);
        Task UpdateById(int id);
        Task DeleteAsSync(int id);
        IEnumerable<OrderDetail> getOrderDetail(string orderID);
    }
}