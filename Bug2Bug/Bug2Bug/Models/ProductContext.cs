using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bug2Bug.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("Bug2Bug")
        {
            //Database.SetInitializer<ProductContext>(null);
        }

        //public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
    }
}