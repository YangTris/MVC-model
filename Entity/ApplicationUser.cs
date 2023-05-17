using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	public class ApplicationUser : IdentityUser
	{

		public string Fristname { get; set; }
		public string Lastname { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }

		/*public ICollection<Payment> Payments { get; set; }*/
	}
}
