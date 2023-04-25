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
        public int paymentID { get; set; }
        public int userID { get; set; }
        public string description { get; set; }
        public DateTime paidDate { get; set; }
        public double ammount { get; set; }
        public PaymentMethod method { get; set; }
    }
}
