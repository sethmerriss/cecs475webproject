<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Bug2Bug.ProtectedContent.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
   </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>
      Select author:&nbsp;
      <asp:DropDownList ID="authorsDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="authorsDropDownList_SelectedIndexChanged" >
      </asp:DropDownList>
   </p>
<p>
      <asp:Label ID="Test" runat="server" Text="Label"></asp:Label>
      <asp:GridView ID="titlesGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  OnRowCommand="titlesGridView_RowCommand" PageSize="4" OnSelectedIndexChanged="titlesGridView_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="titlesGridView_PageIndexChanging" OnSelectedIndexChanging="titlesGridView_SelectedIndexChanging">
         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
          <Columns>
              <asp:ButtonField Text="Add To Cart" CommandName="Add To Cart" />
                      
          </Columns>
         <EditRowStyle BackColor="#999999" />
         <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
         <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#E9E7E2" />
         <SortedAscendingHeaderStyle BackColor="#506C8C" />
         <SortedDescendingCellStyle BackColor="#FFFDF8" />
         <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
      </asp:GridView>
   </p>
   <p>
       <asp:Button ID="Button1" runat="server" PostBackUrl="~/Order.aspx" Text="Done" />
    </p>
</asp:Content>
