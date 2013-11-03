<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Cart.aspx.cs" 
    Inherits="TeamChalchedony.LoggedUsers.Cart" %>

<asp:Content ID="ContentCart" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewOrders" runat="server"
        ItemType="TeamChalchedony.Models.Order"
        DataKeyNames="OrderID">
        <ItemTemplate>
            Product name: <%#: Item.Order_Details.First().Product.ProductName %>
            <br />
            Quantity: <%#: Item.Order_Details.FirstOrDefault().Quantity %>
            <br />
            Price per unit: <%#: Item.Order_Details.FirstOrDefault().UnitPrice %>
            <br />
            Order price: <%#:  Item.Order_Details.FirstOrDefault().Quantity * Item.Order_Details.FirstOrDefault().UnitPrice %>
            <br />
            Shipper: <%#: Item.ShipName %>
        </ItemTemplate>
        <ItemSeparatorTemplate>
            <hr />
        </ItemSeparatorTemplate>
    </asp:ListView>
    <hr />
    Total Sum:
    <asp:Label ID="ProductsTotalSum" runat="server"></asp:Label>
    <br />
    Country:
    <asp:Label ID="ShipCountry" runat="server"></asp:Label>
    <br />
    City:
    <asp:Label ID="ShipCity" runat="server"></asp:Label>
    <br />
    Address:
    <asp:Label ID="ShipAddress" runat="server"></asp:Label>
    <br />
    Required Date:
    <asp:Label ID="RequiredDate" runat="server"></asp:Label>
    <hr />
    <asp:Button ID="SubmitOrderButton" CssClass="btn btn-success" OnClick="SubmitOrderButton_Click" Text="Check Out" runat="server" />
</asp:Content>
