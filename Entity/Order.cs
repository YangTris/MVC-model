using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Order
    {
        [Key]
        public int orderID { get; set; }
        public string userName { get; set; }
        public DateTime created_date { get; set; }
        public Status status { get; set; }
        public double total { get; set; }
        public string confirmed_by { get; set; }
    }
}
