<%@ Page Async="True" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthorClient.aspx.cs" Inherits="Bug2Bug.AuthorClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="AddAuthor" runat="server" Font-Bold="True" Text="Add an Author to the Database"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="AuthorFirstNameLabel" runat="server" Text="First Name:"></asp:Label>
    <br />
    <asp:TextBox ID="firstTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="AuthorLastNameLabel" runat="server" Text="Last Name:"></asp:Label>
    <br />
    <asp:TextBox ID="lastTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Label ID="AuthorPhoneNumberLabel" runat="server" Text="Phone Number:"></asp:Label>
    <br />
    <asp:TextBox ID="phoneTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="AddAuthorButton" runat="server" Text="Add Author" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Get Authors from Database"></asp:Label>
    <br />
    <br />
    <asp:Label ID="GetAuthorLabel" runat="server" Text="Enter the last name of the Author you wish to find:"></asp:Label>
    <br />
    <asp:TextBox ID="findLastTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="GetAuthorButton" runat="server" Text="Get Author" />
    <br />
    <br />
    <br />
    <asp:TextBox ID="resultsTextBox" runat="server"></asp:TextBox>
    <br />
    <br />
</asp:Content>
