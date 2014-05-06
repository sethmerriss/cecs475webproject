﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Net.Http;

namespace Bug2Bug
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
                        "http://localhost:52430/AuthorsRESTXMLService.svc/AddAuthor/" 
                        + resultsTextBox.Text));

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    resultsTextBox.Text = "Entry added successfully";
                else 
                    resultsTextBox.Text = "AddEntry failed with HTTP code " + 
                        response.StatusCode;
            }//end if

            //Search authors by last name
            {
                String result = await client.GetStringAsync(new Uri(
                    "http://localhost:52430/ AuthorsRESTXMLService.svc /GetAuthors/"
                    + resultsTextBox.Text));

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
                        resultsTextBox.Text = element.Element(xmlNamespace + "LastName").Value;
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