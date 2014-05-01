using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Bug2Bug.RESTXMLService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthorsRESTXMLService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthorsRESTXMLService.svc or AuthorsRESTXMLService.svc.cs at the Solution Explorer and start debugging.
    public class AuthorsRESTXMLService : IAuthorsRESTXMLService
    {
        [DataContract]
        public class AuthorEntry
        {
            [DataMember]
            public string LastName { get; set; }

            [DataMember]
            public string FirstName { get; set; }

            public AuthorEntry()
            { }

            public override string ToString()
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
