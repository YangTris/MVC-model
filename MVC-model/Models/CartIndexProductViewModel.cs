﻿using Entity;

namespace MVC_model.Models
{
    public class CartIndexProductViewModel
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public string brand { get; set; }
        public double? price { get; set; }
        public Category category { get; set; }
        public string imgURL { get; set; }
        public int discountPercentage { get; set; }
        /*public DateTime created_at { get; set; }
        public DateTime modified_at { get; set; }
        public DateTime deleted_at { get; set; }
        public string create_by { get; set; }*/
    }
}
