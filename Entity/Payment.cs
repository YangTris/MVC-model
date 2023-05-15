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
    public class Payment
    {
        [Key]
        public string paymentID { get; set; }
        /*[ForeignKey("ApplicationUser")]*/
        [ForeignKey("IdentityUser")]
        public string userID { get; set; }
        public IdentityUser IdentityUser { get; set; }
        /*public ApplicationUser? ApplicationUser { get; set; }*/
        public string method { get; set; }
        public string nameOnCard { get; set; }
        public int cardNumber { get; set; }
        public DateTime expiration { get; set; }
        public string CVV { get; set; }
        public IEnumerable<Item> listItem { get; set; }
    }
}
