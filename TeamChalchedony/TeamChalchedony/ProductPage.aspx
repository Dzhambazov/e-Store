<%@ Page Title="Product Page" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs"
    Inherits="TeamChalchedony.ProductPage" %>

<asp:Content ID="ContentProduct" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PanelProduct" runat="server">
        <h1>
            <asp:Label ID="LabelProductName" runat="server"></asp:Label>
        </h1>
        <img id="ProductImage" runat="server" alt="product" width="150" height="150" />
        <br />
        Quantity per unit:
        <strong>
            <asp:Label ID="LabelQuantityPerUnit" runat="server"></asp:Label>
        </strong>
        <br />
        Unit price:
        <strong>
            <asp:Label ID="LabelUnitPrice" runat="server"></asp:Label>
        </strong>
        <br />
        Units in stock:
        <strong>
            <asp:Label ID="LabelUnitsInStock" runat="server"></asp:Label>
        </strong>
        <br />

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Label Text="Shipper:" AssociatedControlID="DropDownShippers" runat="server" />
                <asp:DropDownList ID="DropDownShippers" class="btn dropdown-toggle" runat="server"
                    DataTextField="CompanyName" DataValueField="ShipperID">
                </asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:Label ID="LabelQuantity" runat="server"></asp:Label>
        <asp:TextBox ID="TextBoxQuantity" TextMode="Number" runat="server" />
        <asp:Button ID="ButtonAddToCart" class="btn btn-primary" Text="Add to Cart" runat="server"
            OnClick="OnButtonAddToCart_Click"></asp:Button>
    </asp:Panel>
</asp:Content>
