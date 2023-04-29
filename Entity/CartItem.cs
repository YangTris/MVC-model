using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class CartItem
    {
        [Key]
        public string cartID { get; set; }
        [ForeignKey("IdentityUser")]
        public string userID { get; set; }
        public IdentityUser? user {  get; set; }
        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }
        [ForeignKey("Product")]
        public int productId { get; set; }
        public Product? product { get; set; }
    }
}
