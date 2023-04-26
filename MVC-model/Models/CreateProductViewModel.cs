using Entity;
using System.ComponentModel.DataAnnotations;

namespace MVC_model.Models
{
    public class CreateProductViewModel
    {
        [Key]
        public int productID { get; set; }
        public string productName { get; set; }
        public string brand { get; set; }
        public int price { get; set; }
        public Category category { get; set; }
        public IFormFile imgURL { get; set; }
        public int discountPercentage { get; set; }
        public DateTime created_at { get; set; }
        public DateTime modified_at { get; set; }
        public DateTime deleted_at { get; set; }
        public string create_by { get; set; }
    }
}
