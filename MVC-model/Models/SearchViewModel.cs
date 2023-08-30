using Entity;

namespace MVC_model.Models
{
    public class SearchViewModel
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public string brand { get; set; }
        public double? price { get; set; }
        public Category category { get; set; }
        public string imgURL { get; set; }
        public int discountPercentage { get; set; }
        public string itemID { get; set; }
        public int quantity { get; set; }
        public string userID { get; set; }
    }
}
