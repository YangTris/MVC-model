using Entity;
using System.ComponentModel.DataAnnotations;

namespace MVC_model.Models
{
    public class IndexPaymentViewModel
    {
        [Key]
        public string paymentID { get; set; }
        public string userID { get; set; }
        public string method { get; set; }
        public string? nameOnCard { get; set; }
        public int? cardNumber { get; set; }
        public DateTime expiration { get; set; }
        public string? CVV { get; set; }
    }
}
