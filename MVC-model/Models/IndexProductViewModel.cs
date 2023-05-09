using Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_model.Models
{
    public class IndexProductViewModel
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public string brand { get; set; }
        public int? price { get; set; }
        public Category category { get; set; }
        public string imgURL { get; set; }
        public int discountPercentage { get; set; }
        /*public DateTime created_at { get; set; }
        public DateTime modified_at { get; set; }
        public DateTime deleted_at { get; set; }
        public string create_by { get; set; }*/
        public string itemID { get; set; }
        public int quantity { get; set; }
        public string userID { get; set; }
    }
}
