using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Bug2Bug
{
    public partial class AuthorClient : System.Web.UI.Page
    {
        //create an object to invoke to the web service
        private HttpClient client = new HttpClient();

        //namespace of the XML response
        private XNamespace xmlNamespace =
            XNamespace.Get("http://schemas.datacontract.org/2004/07/Bug2Bug");


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                clearFields();
            }
        }

        protected async void GetAuthorButton_Click(object sender, EventArgs e)
        {
            resultListBox.Items.Clear();
            String result = await client.GetStringAsync(new Uri("http://localhost:52430/AuthorsWCFService.svc/GetAuthors/" + findLastTextBox.Text));

            XDocument xmlResponse = XDocument.Parse(result); //parse the returned XML string

            //if there are no phone book entries in response
            if (xmlResponse.Element(xmlNamespace + "ArrayOfAuthorEntry").Value == string.Empty) //Root Element
            {
                resultListBox.Items.Add("Not found");
            }
            else
            {
                //print informatino for each phone book entry
                foreach (XElement element in xmlResponse.Element(xmlNamespace + "ArrayOfAuthorEntry").Elements())
                {
                    resultListBox.Items.Add(element.Element(xmlNamespace + "FirstName").Value +" "+ element.Element(xmlNamespace + "LastName").Value);
                }
            }//end else
        }

        protected async void AddAuthorButton_Click(object sender, EventArgs e)
        {
            //send request to AuthorRESTXMLService if fields are filled
            resultListBox.Items.Clear();
            HttpResponseMessage response =
                await client.GetAsync(new Uri(
                    "http://localhost:52430/AuthorsWCFService.svc/AddAuthor/"
                    + firstTextBox.Text + "/" +lastTextBox.Text));

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                resultListBox.Items.Add("Entry added successfully");
            else
                resultListBox.Items.Add("AddEntry failed with HTTP code " + response.StatusCode);
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void clearFields()
        {
            resultListBox.Items.Clear();
            firstTextBox.Text = string.Empty;
            lastTextBox.Text = string.Empty;
            phoneTextBox.Text = string.Empty;
            findLastTextBox.Text = string.Empty;
        }
    }
}