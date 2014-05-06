using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Bug2Bug.AuthorsRESTXMLService
{
    public class AuthorsRESTXMLService : IAuthorsRESTXMLService
    {
        private BooksEntities dbcontext = new BooksEntities();

        public void AddEntry(string fname, string lname)
        {
            AuthorEntry author = new AuthorEntry();
            {
                author.FirstName = fname;
                author.LastName = lname;
            };

            //dbcontext.Authors.Add(AuthorEntry);
            dbcontext.SaveChanges();

        }

        public AuthorEntry[] GetAuthors(string lastName)
        {
            var matchingEntries = 
                from Author in dbcontext.Authors
                where lastName == Author.LastName   
                select new AuthorEntry{
                    LastName = lastName,
                    FirstName = Author.FirstName,
                };

            return matchingEntries.ToArray();
    }
    }
}
