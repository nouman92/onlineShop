using onlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onlineShop.Controllers
{
    public class HomeController : Controller
    {
        //Database1Entities db = new Database1Entities();
        
        IUserRepository userRepo;
        public HomeController(IUserRepository user)
        {
            userRepo = user;
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {

            return View(userRepo.allProducts());
        }
        public ActionResult details()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
       [HttpPost]
        public ActionResult contactUs(contactU comments)
        {
            //contactU obj = new contactU();
            
           // db.contactUs.Add(obj);
            //db.SaveChanges();
            userRepo.saveComments(comments);
            return RedirectToAction("Index");
        }
        public ActionResult contact()
       {
           return View();
       }
        public ActionResult WebCam()
        {
            return View(userRepo.allProducts());
        }
        public ActionResult Mobile()
        {
            return View(userRepo.allProducts());
        }
        public ActionResult Laptops()
        {
            return View(userRepo.allProducts());
        }

    }
}
