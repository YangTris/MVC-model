using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrderDetail
    {
        [ForeignKey("Order")]
        public int orderID { get; set; }
        public Order? order { get; set; }
        [ForeignKey("Product")]
        public int productID { get; set; }
        public Product? product { get; set; }
        public int quantity { get; set; }
        public double subTotal { get; set; }

    }
}
