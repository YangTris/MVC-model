using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrderDetail
    {
        [Key]
        public int orderDetailID { get; set; }
        [ForeignKey("Product")]
        public int productID { get; set; }
        public virtual Product product { get; set; }
        public int quantity { get; set; }
        public string productName { get; set; }
        public double? productPrice { get; set; }
        [ForeignKey("Order")]
        public string orderID { get; set; }
        public virtual Order? order { get; set; }
    }
}
