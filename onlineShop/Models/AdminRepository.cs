using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace onlineShop.Models
{
    public class AdminRepository : IAdminRepository
    {
        Database1Entities db = new Database1Entities();
        public List<contactU> checkComments()
        {
            return db.contactUs.ToList();
        }
        public void addProductDb(product p)
        {
            try
            {
                db.products.Add(p);
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
        public List<product> allProducts()
        {
            return db.products.ToList();
        }
        public void  DeleteProduct(int id)
        {
            product p = db.products.Find(id);
            db.products.Remove(p);
            db.SaveChanges();
        }
        public product updateProduct(int id)
        {
            product p = db.products.Find(id);

            if (p != null)
            {
                return p;
            }
            else
                return null;
        }
        public  void UpdateProductDB(product p)
        {
            var product = db.products.Find(p.productId);
            db.SaveChanges();
        }
    }
}