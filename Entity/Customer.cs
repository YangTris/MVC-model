using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Customer
    {
        [Key] 
        public int id { get; set; }
        [Required, MaxLength(50)]
        public string fullName { get; set; }
        public string? brand { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        public string address { get; set; }
        
    }
}
