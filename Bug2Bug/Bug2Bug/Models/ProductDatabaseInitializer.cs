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
        //static BooksEntities dbcontext = new BooksEntities();

        protected override void Seed(ProductContext context)
        {
            
            //GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<Product> GetProducts()
        {
            //Database.SetInitializer<ProductContext>(null);
            /*//dbcontext.Authors.Load();
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
                            authorname = author.FirstName + " " + author.LastName
                        };
            */
            List<Product> products = new List<Product>()
            {
                new Product
                {
                    ProductISBN = 0132121360,
                    ProductName = "Android for Programmers: An App-Driven Approach",
                    EditionNumber = 1,
                    UnitPrice = 10.00m,
                    copyright = "2012"
                },
                new Product
                {
                    ProductISBN = 0132151006,
                    ProductName = "Internet & World Wide Web How to Program",
                    EditionNumber = 5,
                    UnitPrice = 9.00m,
                    copyright = "2012"
                },
                new Product
                {
                    ProductISBN = 0132575663,
                    ProductName = "Java How to Program",
                    EditionNumber = 9,
                    UnitPrice = 11.00m,
                    copyright = "2012"
                },
                new Product
                {
                    ProductISBN = 0132990444,
                    ProductName = "C How to Program",
                    EditionNumber = 7,
                    UnitPrice = 12.00m,
                    copyright = "2013"
                },
                new Product
                {
                    ProductISBN = 0132990601,
                    ProductName = "Simply Visual Basic 2010", 
                    EditionNumber = 4,
                    UnitPrice = 7.00m,
                    copyright = "2013"
                },
                new Product
                {
                    ProductISBN = 0133378713,
                    ProductName = "C++ How to Program", 
                    EditionNumber = 9,
                    UnitPrice = 5.00m,
                    copyright = "2014"
                },
                new Product
                {
                    ProductISBN = 0133379337,
                    ProductName = "Visual C# 2012 How to Program",
                    EditionNumber = 5,
                    UnitPrice = 9.00m,
                    copyright = "2014"
                },
                new Product
                {
                    ProductISBN = 0133406954,
                    ProductName = "Visual Basic 2012 How to Program",
                    EditionNumber = 6,
                    UnitPrice = 12.00m,
                    copyright = "2014"
                },
                new Product
                {
                    ProductISBN = 0136151574,
                    ProductName = "Visual C++ 2008 How to Program", 
                    EditionNumber = 2,
                    UnitPrice = 11.00m,
                    copyright = "2008"
                },
            };

            /*
            foreach(var item in books)
            {
                Product product = new Product();
                product.ProductISBN = (string)item.ISBN;
                product.ProductName = (string)item.Name;
                product.EditionNumber = (int)item.Edition;
                product.copyright = (string)item.copyright;
                product.UnitPrice = (decimal)item.price;
                product.AuthorName = (string)item.authorname;
                products.Add(product);
            }
             */

            return products;
        }

    }
}