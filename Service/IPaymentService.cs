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
        Payment GetById(int id);
        Task CreateAsSync(Payment payment);
        Task UpdateAsSync(Payment payment);
        Task UpdateById(int id);
        Task DeleteAsSync(int id);
    }
}
