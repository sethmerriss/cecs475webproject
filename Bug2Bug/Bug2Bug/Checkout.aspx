<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Bug2Bug.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="Bug2Bug.Models.CartItem" SelectMethod="GetShoppingCartItems" 
        CssClass="table table-striped table-bordered" >   
        <Columns>
        <asp:BoundField DataField="Product.ProductISBN" HeaderText="ISBN" SortExpression="ProductISBN" />        
        <asp:BoundField DataField="Product.ProductName" HeaderText="Name" />        
        <asp:BoundField DataField="Product.UnitPrice" HeaderText="Price (each)" DataFormatString="{0:c}"/>     
        <asp:TemplateField   HeaderText="Quantity">            
                <ItemTemplate>
                    <asp:Label ID="PurchaseQuantity" Width="40" runat="server" Text="<%#: Item.Quantity %>"></asp:Label> 
                </ItemTemplate>        
        </asp:TemplateField>    
        <asp:TemplateField HeaderText="Item Total">            
                <ItemTemplate>
                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) *  Convert.ToDouble(Item.Product.UnitPrice)))%>
                </ItemTemplate>        
        </asp:TemplateField>    
        </Columns>    
    </asp:GridView>
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Order Total: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong> 
    </div>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Payment Type: "></asp:Label>
    <br />
    <asp:DropDownList ID="CCTypeList" runat="server">
        <asp:ListItem>Visa</asp:ListItem>
        <asp:ListItem>Mastercard</asp:ListItem>
        <asp:ListItem>American Express</asp:ListItem>
        <asp:ListItem>Discover</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Card Number: "></asp:Label>
    <br />
    <asp:TextBox ID="CCNumField" runat="server" OnTextChanged="TextBox1_TextChanged" Width="170px"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="CCReqValidator" runat="server" ControlToValidate="CCNumField" ErrorMessage="Card Number is a required field. "></asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator ID="CCValidator" runat="server" ControlToValidate="CCNumField" ErrorMessage="Card Number must be a 16 digit number or 15 digits for American Express." ValidationExpression="\b(?:3[47]\d|(?:4\d|5[1-5]|65)\d{2}|6011)\d{12}\b"></asp:RegularExpressionValidator>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Security Code:"></asp:Label>
    <br />
    <asp:TextBox ID="CVVCodeBox" runat="server" Width="77px"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="CVVReqValidator" runat="server" ControlToValidate="CVVCodeBox" ErrorMessage="Security Code is a required field."></asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="CVVCodeBox" ErrorMessage="The security code is 4 digits. If your code is three digits, add a leading 0." ValidationExpression="[0-9][0-9][0-9][0-9]"></asp:RegularExpressionValidator>
    <br />
    <br />
    Billing Address:<br />
    <br />
    <asp:TextBox ID="AddressField" runat="server" Height="79px" Width="214px"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="AddressValidator" runat="server" ControlToValidate="AddressField" ErrorMessage="Billing Address is a required field. "></asp:RequiredFieldValidator>
    <br />
    <br />
    <table> 
    <tr>
      <td>
          <br />
        <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" OnClick="CheckoutBtn_Click" />
          <br />
      </td>
    </tr>
    </table>
</asp:Content>
