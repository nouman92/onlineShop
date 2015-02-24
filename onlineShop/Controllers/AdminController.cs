using onlineShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onlineShop.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
       // Database1Entities db = new Database1Entities();

        IAdminRepository adminRepo;

        public AdminController(IAdminRepository admin)
        {
            adminRepo = admin;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminHome()
        {

            return View(adminRepo.allProducts());

        }
        public ActionResult viewComments()
        {
           // List<contactU> commentList = new List<contactU>();
            
            return View(adminRepo.checkComments());
        }
        public ActionResult AddProduct()
        {

            return View();
        }
        [HttpPost]

        public ActionResult addProduct(product p)
        {
            HttpPostedFileBase file = Request.Files[0];
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/Files/"), fileName);
            file.SaveAs(path);
            path = "/Files/" + fileName;
            p.productImage = path;
            adminRepo.addProductDb(p);
            return View();
        }
        public ActionResult DeleteProduct(int id)
        {
            adminRepo.DeleteProduct(id);
            return RedirectToAction("AdminHome");
        }
        public ActionResult updateProduct(int id)
        {
            return View(adminRepo.updateProduct(id));
        }
        [HttpPost]
        public ActionResult  UpdateProductDB(product p)
        {
            adminRepo.UpdateProductDB(p);
            return RedirectToAction("AdminHome");
        }
    }
}
