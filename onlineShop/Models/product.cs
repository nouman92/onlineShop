//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace onlineShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        public product()
        {
            this.carts = new HashSet<cart>();
            this.orderDetails = new HashSet<orderDetail>();
        }
    
        public int productId { get; set; }
        public string productName { get; set; }
        public string productCompany { get; set; }
        public string productColor { get; set; }
        public string productQuantity { get; set; }
        public string productPrice { get; set; }
        public string productImage { get; set; }
    
        public virtual ICollection<cart> carts { get; set; }
        public virtual ICollection<orderDetail> orderDetails { get; set; }
    }
}
