using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop.Models
{
   public  interface IUserRepository
    {
        void saveUser(user user);
        void saveComments(contactU comments);

        bool login(string email, string pass);

        bool checkName(string userName);

        List<product> allProducts();
    }
}
