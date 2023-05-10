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
    public class Transaction
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userID { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public int paymentID { get; set; }
        public string method { get; set; }
        public string nameOnCard { get; set; }
        public int cardNumber { get; set; }
        public DateTime expiration { get; set; }
        public string CVV { get; set; }
        public int CartId { get; set; }
        public IEnumerable<Item> items { get; set; }
    }
}
