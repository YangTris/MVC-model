using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Payment
    {
        [Key]
        public string paymentID { get; set; }
        public DateTime paidDate { get; set; }
        public double totalPrice { get; set; }
        public string detail { get; set; }
        public PaymentMethod method { get; set; }
    }
}
