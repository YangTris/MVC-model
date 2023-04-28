using Entity;
using System.ComponentModel.DataAnnotations;

namespace MVC_model.Models
{
    public class IndexOrderViewModel
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
