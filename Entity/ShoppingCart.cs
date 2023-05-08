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
    public class ShoppingCart
    {
        [Key]
        public int shoppingCartID { get; set; }
        [ForeignKey("IdentityUser")]
        public string userID { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
