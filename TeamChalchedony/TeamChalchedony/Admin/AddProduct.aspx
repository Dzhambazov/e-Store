<%@  Page Title="Add Product" Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="TeamChalchedony.Admin.AddProduct" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h1>Add product</h1>
    <div id="EditProductWrapper">

        <asp:Label ID="Label1" Text="Product name: " runat="server" AssociatedControlID="ProductName" />
        <asp:TextBox runat="server" ID="ProductName"></asp:TextBox>
<%--        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Product name cannot be empty" ControlToValidate="ProductName" runat="server" CssClass="text-error" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="ProductName" runat="server" CssClass="text-error" ValidationExpression="^[\s\S]{0,40}$" Text="The product name has to be 40 characters at most" />--%>

        <asp:Label ID="Label2" Text="Quantity per unit: " runat="server" AssociatedControlID="ProductName" />
        <asp:TextBox runat="server" ID="QuantityPerUnit"></asp:TextBox>
<%--        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" CssClass="text-error" ControlToValidate="QuantityPerUnit" runat="server" ValidationExpression="^[\s\S]{0,20}$" Text="The quantity per unit has to be 20 characters at most" />--%>

        <asp:Label ID="Label3" Text="Unit price: " runat="server" AssociatedControlID="UnitPrice" />
        <asp:TextBox runat="server" ID="UnitPrice"></asp:TextBox>
<%--        <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="text-error" ControlToValidate="UnitPrice" Type="Currency"
            Operator="DataTypeCheck" ErrorMessage="Invalid price" />
        <asp:RangeValidator ID="RangeValidator1" ErrorMessage="Invalid price" CssClass="text-error" ControlToValidate="UnitPrice" runat="server" MinimumValue="0" MaximumValue="922337203685477.5807" />--%>

        <asp:Label ID="Label4" Text="Units in stock: " runat="server" AssociatedControlID="UnitsInStock" />
        <asp:TextBox runat="server" ID="UnitsInStock"></asp:TextBox>
<%--        <asp:CompareValidator ID="CompareValidator2" ErrorMessage="Invalid number of units" CssClass="text-error" ControlToValidate="UnitsInStock" runat="server" Type="Integer" Operator="DataTypeCheck" />
        <asp:RangeValidator ID="RangeValidator2" ErrorMessage="Invalid number of units" CssClass="text-error" ControlToValidate="UnitsInStock" runat="server" MinimumValue="0" MaximumValue="32767" />--%>

        <asp:Label ID="Label5" Text="Categories:" AssociatedControlID="CategoryDropDown" runat="server" />
        <asp:DropDownList runat="server" ID="CategoryDropDown" >
        </asp:DropDownList>
        <br />
        <br />

        <asp:Button Text="Create product" runat="server" ID="AddProductSubmit" OnClick="AddProductSubmit_Click" CssClass="btn btn-primary" />
    </div>

    <div id="ImageControl">
        <asp:Label ID="Label6" Text="Add image:" AssociatedControlID="ImageUpdateUpload" runat="server" />
        <asp:FileUpload runat="server" ID="ImageUpdateUpload" CssClass="btn btn-info" AllowMultiple="false"/>
    </div>
</asp:Content>
