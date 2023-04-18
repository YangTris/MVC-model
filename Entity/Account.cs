using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Account
    {
        [Key]
        public string id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
    }
}
