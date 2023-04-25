using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        [Key]
        public int productID { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public int price { get; set; }
        public Category category { get; set; }
        public string imgURL { get; set; }
        public int discountPercentage { get; set; }
        public DateTime created_at { get; set; }
        public DateTime modified_at { get; set; }
        public DateTime deleted_at { get; set; }
        public string create_by { get; set; }
    }
}