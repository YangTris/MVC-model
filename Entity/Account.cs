using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Account
    {
        [Key]
        public string id { get; set; }
        public string billingAddress { get; set; }
        public Boolean isClosed { get; set; }
        public DateTime open { get;set; }
        public DateTime closed { get;set; }
        public string customerID { get; set; }
        public string orderID { get; set; }
    }
}
