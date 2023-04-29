using Entity;
using System.ComponentModel.DataAnnotations;

namespace MVC_model.Models
{
    public class TransactionViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public PaymentMethod method { get; set; }
        public string nameOnCard { get; set; }
        public int cardNumber { get; set; }
        public DateTime expiration { get; set; }
        public string CVV { get; set; }
        public string ItemId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }

    }
}
