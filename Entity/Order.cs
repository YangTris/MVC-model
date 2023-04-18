using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Order
    {
        [Key]
        public string orderId { get; set; }
        public string accountId { get; set; }
        public string productID { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
    }
}
