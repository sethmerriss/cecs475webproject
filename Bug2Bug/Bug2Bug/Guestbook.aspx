<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Guestbook.aspx.cs" Inherits="Bug2Bug.Guestbook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 121px;
    }
    .textBodWidth {
        width: 300px;
    }
    .textBoxHeight {
        height: 100px;
    }
    .auto-style2 {
        width: 121px;
        height: 64px;
    }
    .auto-style3 {
        height: 64px;
            width: 696px;
        }
    .auto-style4 {
        width: 121px;
        height: 151px;
    }
    .auto-style5 {
        height: 151px;
            width: 696px;
        }
        .gridViewWidth {
        }
        .auto-style6 {
            width: 696px;
        }
    .gridViewWidth {
        width: 650px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3 aria-setsize="14" style="height: 1083px" aria-expanded="true" aria-multiline="True">Please leave a message in our guestbook:<table style="width: 100%; height: 524px;">
    <tr>
        <td class="auto-style1">Name:</td>
        <td class="auto-style6">
            <asp:TextBox ID="nameTextBox" runat="server" CssClass="textBodWidth"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="nameRequiredFieldValidator1" runat="server" ControlToValidate="nameTextBox" Display="Dynamic" ErrorMessage="Please enter your name" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">E-mail:</td>
        <td class="auto-style6">
            <asp:TextBox ID="emailTextBox" runat="server" CssClass="textBodWidth" TextMode="Email"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="emailRequiredFieldValidator1" runat="server" ControlToValidate="emailTextBox" Display="Dynamic" ErrorMessage="Please enter an e-mail" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="emailRegularExpressionValidator1" runat="server" ControlToValidate="emailTextBox" Display="Dynamic" ErrorMessage="Please enter an e-mail address in a valid format" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">Tell the world:</td>
        <td class="auto-style5">
            <asp:TextBox ID="messageTextBox" runat="server" CssClass="textBoxHeight" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="messageRequiredFieldValidator1" runat="server" ControlToValidate="messageTextBox" Display="Dynamic" ErrorMessage="Please enter your comments" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2"></td>
        <td class="auto-style3">
            &nbsp;<asp:Button ID="clearButton" runat="server" OnClick="clearButton_Click" Text="Clear" />
                    <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="Submit" />
                    <asp:GridView ID="messagesGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="gridViewWidth" DataKeyNames="MessageID" DataSourceID="messageEntityDataSource" ForeColor="#333333" GridLines="None" Height="273px" Width="515px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            <asp:BoundField DataField="Message1" HeaderText="Message" SortExpression="Message1" />
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
                    <asp:EntityDataSource ID="messageEntityDataSource" runat="server" ConnectionString="name=GuestbookEntities" DefaultContainerName="GuestbookEntities" EnableFlattening="False" EntitySetName="Messages">
                    </asp:EntityDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    </table>
</h3>
</asp:Content>

