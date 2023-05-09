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
    public class Item
    {
        [Key]
        public string itemID { get; set; }
        public Product product { get; set; }
        public int quantity { get; set; }
        [ForeignKey("IdentityUser")]
        public string userID { get; set; }
        public virtual IdentityUser user { get; set; }
    }
}
