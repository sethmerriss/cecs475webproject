using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bug2Bug
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthorsWCFService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthorsWCFService.svc or AuthorsWCFService.svc.cs at the Solution Explorer and start debugging.
    public class AuthorsWCFService : IAuthorsWCFService
    {
        public void AddEntry( string FirstName, string lastName)
        {
            BooksEntities dbcontext = new BooksEntities();
            Author author = new Author();
            {
                author.FirstName = FirstName;
                author.LastName = lastName;
            };

            dbcontext.Authors.Add(author);
            dbcontext.SaveChanges();

        }

        public AuthorEntry[] GetAuthors(string lastName)
        {
            BooksEntities dbcontext = new BooksEntities();
            var matchingEntries =
                from Author in dbcontext.Authors
                where lastName == Author.LastName
                select new AuthorEntry
                {
                    LastName = lastName,
                    FirstName = Author.FirstName,
                };

            return matchingEntries.ToArray();
        }
    }
}
