using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Transaction
    {
        public string? userName;

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userID { get; set; }
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
