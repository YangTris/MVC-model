using Entity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_model.Models
{
    public class CartIndexProductViewModel
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
