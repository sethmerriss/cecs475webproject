using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace Bug2Bug
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