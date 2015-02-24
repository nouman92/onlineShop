using onlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onlineShop.Controllers
{
    public class AccountController : Controller
    {
       // Database1Entities db = new Database1Entities();
        //
        // GET: /Account/
        IUserRepository userRepo;
        public AccountController(IUserRepository user)
        {
            userRepo = user;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult createAccount(user create_user)
        {
            if(ModelState.IsValid)
            { 
            //db.users.Add(create_user);
            //db.SaveChanges();
            userRepo.saveUser(create_user);
           }

            return RedirectToAction("Index","Home");
        }
        public JsonResult checkUserName()
        {
            string name = Request["name"];
            bool flag = false;
            flag = userRepo.checkName(name);
            return this.Json(flag, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult verifyUserLogin()
        {
            string email = Request["Email"];
           string pass = Request["Password"]; 
           // var q = from x in db.users select 
          //foreach(var v in db.users)
          //{
          //    if(v.Email.Equals(u.Email) && v.Password.Equals(u.Password))
          //    {
          //        return RedirectToAction("");
          //    }
          //}
           if(userRepo.login(email, pass))
           {
               return View("Login");
           }
           return RedirectToAction("Index", "Home");
          
            
        }

    }
}
