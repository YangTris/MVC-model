using System.ComponentModel.DataAnnotations;

namespace MVC_model.Models
{
    public class DetailProductViewModel
    {
        [Key]
        public int productID { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string imgURL { get; set; }
        public DateTime inDate { get; set; }
    }
}
