using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bug2Bug.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        // Entity Framework DbContext
        static BooksEntities dbcontext = new BooksEntities();

        protected override void Seed(ProductContext context)
        {
            //GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<Product> GetProducts()
        {
            //dbcontext.Authors.Load();
            dbcontext.Titles.Load();

            var books = from book in dbcontext.Titles
                        from author in book.Authors
                        select new
                        {
                            ISBN = book.ISBN,
                            Name = book.Title1,
                            Edition = book.EditionNumber,
                            copyright = book.Copyright,
                            price = book.Price,
                            author = author.FirstName + " " + author.LastName
                        };

            List<Product> products = new List<Product>();

            foreach(var item in books)
            {
                Product product = new Product();
                product.ProductISBN = (string)item.ISBN;
                product.ProductName = (string)item.Name;
                product.EditionNumber = (int)item.Edition;
                product.copyright = (string)item.copyright;
                product.UnitPrice = (decimal)item.price;
                product.AuthorName = (string)item.author;
                products.Add(product);
            }

            return products;
        }

    }
}