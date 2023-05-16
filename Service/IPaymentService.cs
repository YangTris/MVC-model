using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPaymentService
    {
        IEnumerable<Payment> GetAll();
        Payment GetById(string id);
        Task CreateAsSync(Payment payment);
        Task UpdateAsSync(Payment payment);
        Task UpdateById(string id);
        Task DeleteAsSync(string id);
        Payment GetByUserID(string userId);
        //decimal totalPriceCal(IEnumerable<Item> listItem);
    }
}
