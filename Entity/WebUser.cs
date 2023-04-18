using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class WebUser
    {
        public string loginID {  get; set; }
        public string password { get; set; }
        public UserState state { get; set; }
    }
}
