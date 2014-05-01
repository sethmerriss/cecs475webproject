using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bug2Bug
{
    public partial class Guestbook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            //use GuestbookEntities DbContext to add a new message
            using (GuestbookEntities dbcontext = new GuestbookEntities())
            {
                Message message = new Message();

                message.Date = DateTime.Now.ToShortDateString();
                message.Name = nameTextBox.Text;
                message.Email = emailTextBox.Text;
                message.Message1 = messageTextBox.Text;

                dbcontext.Messages.Add(message);
                dbcontext.SaveChanges();
            }

            nameTextBox.Text = String.Empty;
            emailTextBox.Text = String.Empty;
            messageTextBox.Text = String.Empty;

            messagesGridView.DataBind();
        }

        protected void clearButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = String.Empty;
            emailTextBox.Text = String.Empty;
            messageTextBox.Text = String.Empty;
        }
    }
}