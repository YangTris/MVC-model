using Entity;

namespace MVC_model.Models
{
    public class EditProductViewModel
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public string brand { get; set; }
        public double price { get; set; }
        public Category category { get; set; }
        public IFormFile imgURL { get; set; }
        public int discountPercentage { get; set; }
    }
}
