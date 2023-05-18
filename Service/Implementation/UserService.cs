using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) {
            _context = context;
        }
        public ApplicationUser getbyID(string id)
        {
            return _context.ApplicationUser.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
