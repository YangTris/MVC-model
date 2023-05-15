using Entity;
using System.ComponentModel.DataAnnotations;

namespace MVC_model.Models
{
    public class TransactionViewModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userID { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string paymentID { get; set; }
        public string method { get; set; }
        public string nameOnCard { get; set; }
        public int cardNumber { get; set; }
        public DateTime expiration { get; set; }
        public string CVV { get; set; }
        public int CartId { get; set; }
        public IEnumerable<Item> listItem { get; set; }
    }
}
