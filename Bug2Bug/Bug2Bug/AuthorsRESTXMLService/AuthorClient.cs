using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Xml.Linq;

namespace Bug2Bug.AuthorsRESTXMLService
{
    public partial class AuthorClient : System.Web.UI.Page
    {
        //create an object to invoke to the web service
        private HttpClient client = new HttpClient();

        //namespace of the XML response
        private XNamespace xmlNamespace =
            XNamespace.Get("http://schemas.datacontract.org/2004/07/ AuthorRESTXMLService ");

        //handle page load events
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //send request to AuthorRESTXMLService if fields are filled
                HttpResponseMessage response =
                    await client.GetAsync(new Uri(
                        "http://localhost:52163/AuthorsRESTXMLService.svc/AddAuthor/"
                        ____________________________));

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    resultsTextBox.Text = "Entry added successfully";
                else 
                    resultsTextBox.Text = "AddEntry failed with HTTP code " + 
                        response.StatusCode;
            }//end if

            //Search authors by last name
            {
                String result = await client.GetStringAsync(new Uri(
                    "http://localhost:52163/ AuthorsRESTXMLService.svc /GetAuthors/"
                    ____________________________));

                XDocument xmlResponse = XDocument.Parse(result); //parse the returned XML string

                //if there are no phone book entries in response
                if (xmlResponse.Element(xmlNamespace + "ArrayOfAuthorEntry").Value == string.Empty) //Root Element
                {
                }
                else 
                {
                    //print informatino for each phone book entry
                    foreach (XElement element in xmlResponse.Element(xmlNamespace + "ArrayOfAuthorEntry").Elements())
                    {
                        element.Element(xmlNamespace + "LastName").Value,
                    }
                }//end else
            }//end if
        }

        private void clearFields()
        {
            resultsTextBox.Text = string.Empty;
            firstTextBox.Text = string.Empty;
            lastTextBox.Text = string.Empty;
        }
    }
}