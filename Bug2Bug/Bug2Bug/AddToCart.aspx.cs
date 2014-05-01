using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using Bug2Bug.Logic;

namespace Bug2Bug
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow) Session["row"];
            string rawId = row.Cells[1].Text.ToString(); //Request.QueryString["ProductID"];
            int productId = Convert.ToInt32(rawId);
            if (!String.IsNullOrEmpty(rawId)) //&& int.TryParse(rawId, out productId))
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
                    Test2.Text = productId.ToString();
                    usersShoppingCart.AddToCart(productId);
                }

            }
            else
            {
                Debug.Fail("ERROR : We should never get to AddToCart.aspx without a ProductId.");
                throw new Exception("ERROR : It is illegal to load AddToCart.aspx without setting a ProductId.");
            }
            Response.Redirect("~/ProtectedContent/Books.aspx");
        }
    }
}