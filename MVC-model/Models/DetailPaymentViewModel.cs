using Entity;
using System.ComponentModel.DataAnnotations;

namespace MVC_model.Models
{
    public class DetailPaymentViewModel
    {
        [Key]
        public int paymentID { get; set; }
        public string userID { get; set; }
        public PaymentMethod method { get; set; }
        public string nameOnCard { get; set; }
        public int cardNumber { get; set; }
        public DateTime expiration { get; set; }
        public string CVV { get; set; }
    }
}
