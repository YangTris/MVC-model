using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IItemService
    {
        Item GetById(int id);
        Task CreateAsSync(Item item);
        Task UpdateAsSync(Item item);
        Task UpdateById(int id);
        Task DeleteAsSync(int id);
        // IEnumerable<Item> GetCart(int id);
        bool CheckItem(string userID, int productID);
        public IEnumerable<Item> getUserItem(string userID);
        Task DeleteUserItem(string userID);
    }
}
