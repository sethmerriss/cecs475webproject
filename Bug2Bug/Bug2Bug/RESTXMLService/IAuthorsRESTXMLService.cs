using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Bug2Bug.RESTXMLService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthorsRESTXMLService" in both code and config file together.
    [ServiceContract]
    public interface IAuthorsRESTXMLService
    {
        [OperationContract]
        [WebGet(UriTemplate =
            "AddAuthor/{lastName}")]
        void AddEntry(string lastName, string FirstName);

        [OperationContract]
        [WebGet(UriTemplate = "GetAuthors/{lastName}")]
        AuthorEntry[] GetAuthors(string lastName);
    }
}
