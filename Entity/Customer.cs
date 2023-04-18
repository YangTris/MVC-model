using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Customer
    {
        [Key] 
        public string id { get; set; }
        [Required, MaxLength(50)]
        public string fullName { get; set; }
        public string? gender { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        public string address { get; set; }
        
    }
}
