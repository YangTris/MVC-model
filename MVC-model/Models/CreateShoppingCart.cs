using Entity;
using System.ComponentModel.DataAnnotations;

namespace MVC_model.Models
{
    public class CreateShoppingCart
    {
        public int shoppingCartID { get; set; }
        public string userID { get; set; }
    }
}
