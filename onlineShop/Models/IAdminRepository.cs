using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShop.Models
{
   public interface IAdminRepository
    {
       List<contactU> checkComments();
       void addProductDb(product p);

       List<product> allProducts();

       void DeleteProduct(int id);
       product updateProduct(int id);
       void UpdateProductDB(product p);
    }
}
