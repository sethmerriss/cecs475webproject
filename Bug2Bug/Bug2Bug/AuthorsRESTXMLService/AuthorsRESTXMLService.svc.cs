using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bug2Bug.AuthorsRESTXMLService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthorsRESTXMLService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthorsRESTXMLService.svc or AuthorsRESTXMLService.svc.cs at the Solution Explorer and start debugging.
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
