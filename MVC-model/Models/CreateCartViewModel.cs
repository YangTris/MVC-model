using Entity;
using System.ComponentModel.DataAnnotations;

namespace MVC_model.Models
{
    public class CreateCartViewModel
    {
        public int itemID { get; set; }
        public int productID { get; set; }
        public int quantity { get; set; }
        public int cartID { get; set; }
    }
}
