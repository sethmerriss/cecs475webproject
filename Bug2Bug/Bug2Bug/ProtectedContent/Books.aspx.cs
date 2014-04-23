// Fig. 29.11: Books.aspx.cs
// Code-behind file for the password-protected Books page.
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;

namespace Bug2Bug.ProtectedContent
{
   public partial class Books : System.Web.UI.Page
   {
      // Entity Framework DbContext
      BooksEntities dbcontext = new BooksEntities();

      // Load event handler for Books page
      protected void Page_Load(object sender, EventArgs e)
      {
         // if this is the first time the page is loading
         if (!IsPostBack)
         {
            dbcontext.Authors.Load(); // load Authors table into memory

            // LINQ query that populates authorsDropDownList
            var authorsQuery =
               from author in dbcontext.Authors.Local
               orderby author.LastName, author.FirstName
               select new
               {
                  Name = author.LastName + ", " + author.FirstName,
                  author.AuthorID
               };

            // specify the field used as the selected value
            authorsDropDownList.DataValueField = "AuthorID";

            // specify the field displayed in the DropDownList
            authorsDropDownList.DataTextField = "Name";

            // set authorsQuery as the authorsDropDownList's data source
            authorsDropDownList.DataSource = authorsQuery;

            authorsDropDownList.DataBind(); // displays query results
         } // end if
      } // end method Page_Load

      // display selected author's books
      protected void authorsDropDownList_SelectedIndexChanged(
         object sender, EventArgs e)
      {
         dbcontext.Authors.Load(); // load Authors table into memory

         // use LINQ to get Author object for the selected author
         Author selectedAuthor =
            (from author in dbcontext.Authors.Local
             where author.AuthorID == 
                Convert.ToInt32(authorsDropDownList.SelectedValue)
             select author).First();

         // query to get books for the selected author
         var titlesQuery =
            from book in selectedAuthor.Titles
            orderby book.Title1
            select book;

         // set titlesQuery as the titlesGridView's data source
         titlesGridView.DataSource = titlesQuery;
         titlesGridView.DataBind(); // displays query results  
      }

      protected void grdtest_RowCommand(object sender, GridViewCommandEventArgs e)
      {
          if (e.CommandName == "Add To Cart")
          {
              int Index = Convert.ToInt32(e.CommandArgument);
              GridViewRow row = titlesGridView.Rows[Index];
              int id = Convert.ToInt32(row.Cells[0].Text);
              Session["row"] = row;
              //if you want to select the text of different cells like `coursename` and `coursecode` then assign their cell number,it always start from 0.
              // Now you have the data of selected row.
              // Do what ever you want.
          }
      }
      protected void titlesGridView_SelectedIndexChanged(object sender, EventArgs e)
      {

      } // end method authorsDropDownList_SelectedIndexChanged
   } // end class Books
} // end namespace Bug2Bug.ProtectedContent


/**************************************************************************
 * (C) Copyright 1992-2014 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/
