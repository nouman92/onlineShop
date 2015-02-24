using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace onlineShop.Models
{
    public class UserRepository:IUserRepository
    {
        Database1Entities db = new Database1Entities();
        public void saveUser(user u)
        {
            db.users.Add(u);
            db.SaveChanges();
        }
        public void saveComments(contactU comments)
        {
            db.contactUs.Add(comments);
            db.SaveChanges();
        }
       public bool checkName(string userName)
        {
            var q = from u in db.users
                    where u.Email.Equals(userName)
                    select u;
            if(q.Count() !=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool login(string email,string pass)
        {
            var q = from u in db.users
                    where (u.Email.Equals(email) && u.Password.Equals(pass))
                    select u;
            if (q.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<product> allProducts()
        { 
            return db.products.ToList();
        }
    }
}