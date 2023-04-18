using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Customer
    { 
        public string id { get; set; }
        [Required, MaxLength(50)]
        public string fullName { get; set; }
        public string? gender { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        public string address { get; set; }
        
    }
}
