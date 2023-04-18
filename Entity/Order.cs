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
        public string orderID { get; set; }
        public DateTime ordered { get; set; }
        public DateTime shipped { get; set; }
        public string orderAddress { get; set; }
        public OrderStatus status { get; set; }
        public double totalPrice { get; set; }
    }
}
