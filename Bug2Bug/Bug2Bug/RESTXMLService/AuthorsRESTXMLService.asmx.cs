using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Bug2Bug.RESTXMLService
{
    public class AuthorsRESTXMLService : IAuthorsRESTXMLService
    {
        private BooksEntities dbcontext = new BooksEntities();

        public void AddAuthor(string fname, string lname)
        {
            AuthorEntry author = new AuthorEntry();
            {
                FirstName = fname;
                LastName = lname;

            };

            dbcontext.Authors.Add(author);
            dbcontext.SaveChanges();
            
        }

        public AuthorEntry[] GetAuthors(string lastName)
        {
            var matchingEntries = 
                from Authors in dbcontext.Authors
                where lastName == Authors.LastName.ToString()
                select new AuthorEntry{
                    LastName = lastName,
                    FirstName = something,
        };
            return matchingEntries.ToArray();
    }
    }
}
