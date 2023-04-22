using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrderLine
    {
        [Key]
        public int orderLineID {  get; set; }
        public int orderID { get; set; }
        public int productID { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }

    }
}
