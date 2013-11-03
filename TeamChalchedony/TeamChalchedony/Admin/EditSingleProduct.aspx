<%@ Page Title="Edit Single Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditSingleProduct.aspx.cs" Inherits="TeamChalchedony.Admin.EditProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit product</h1>
    <asp:Label ID="Error" runat="server" />
    <div id="EditProductWrapper">
        <asp:Label Text="Product name: " runat="server" AssociatedControlID="ProductName" />
        <asp:TextBox runat="server" ID="ProductName"></asp:TextBox>
        <%--        <asp:RequiredFieldValidator CssClass="text-error" ErrorMessage="Product name cannot be empty" ControlToValidate="ProductName" runat="server" />
        <asp:RegularExpressionValidator CssClass="text-error" ControlToValidate="ProductName" runat="server" ValidationExpression="^[\s\S]{0,40}$" Text="The product name has to be 40 characters at most" />--%>

        <asp:Label Text="Quantity per unit: " runat="server" AssociatedControlID="ProductName" />
        <asp:TextBox runat="server" ID="QuantityPerUnit"></asp:TextBox>
        <%--        <asp:RegularExpressionValidator CssClass="text-error" ControlToValidate="QuantityPerUnit" runat="server" ValidationExpression="^[\s\S]{0,20}$" Text="The quantity per unit has to be 20 characters at most" />--%>

        <asp:Label Text="Unit price: " runat="server" AssociatedControlID="UnitPrice" />
        <asp:TextBox runat="server" ID="UnitPrice"></asp:TextBox>
        <%--        <asp:CompareValidator runat="server" CssClass="text-error" ControlToValidate="UnitPrice" Type="Currency"
            Operator="DataTypeCheck" ErrorMessage="Invalid price" />
        <asp:RangeValidator ErrorMessage="Invalid price" CssClass="text-error" ControlToValidate="UnitPrice" runat="server" MinimumValue="0" MaximumValue="922337203685477.5807" />--%>

        <asp:Label Text="Units in stock: " runat="server" AssociatedControlID="UnitsInStock" />
        <asp:TextBox runat="server" ID="UnitsInStock"></asp:TextBox>
        <%--        <asp:CompareValidator ErrorMessage="Invalid number of units" CssClass="text-error" ControlToValidate="UnitsInStock" runat="server" Type="Integer" Operator="DataTypeCheck" />
        <asp:RangeValidator ErrorMessage="Invalid number of units" CssClass="text-error" ControlToValidate="UnitsInStock" runat="server" MinimumValue="0" MaximumValue="32767" />--%>

        <asp:Label Text="Categories:" AssociatedControlID="CategoryDropDown" runat="server" />
        <asp:DropDownList runat="server" ID="CategoryDropDown" CssClass="btn">
        </asp:DropDownList>
        <br />
        <br />

        <asp:Button Text="Save changes" runat="server" ID="EditProductSubmit" OnClick="EditProductSubmit_Click" CssClass="btn btn-primary" />
        <asp:Button Text="Delete product" runat="server" ID="DeleteProductButton" OnClick="DeleteProductButton_Click" CssClass="btn btn-danger" />

        <asp:Panel runat="server" ID="DeleteDialog" GroupingText="Confirm delete">
            <strong>
                <asp:Label Text="Are you sure you want to delete this product?" runat="server" />
            </strong>
            <br />
            <asp:Button Text="Yes" runat="server" CssClass="btn btn-danger" ID="ConfirmDelete" OnClick="ConfirmDelete_Click" />
            <asp:Button Text="No" CssClass="btn" runat="server" ID="CancelDelete" OnClick="CancelDelete_Click" />
        </asp:Panel>
    </div>

    <div id="ImageControl">
        <asp:Image runat="server" ID="ProductImage" Width="200px" Height="200px" />

        <br />

        <asp:Label Text="Change image:" AssociatedControlID="ImageUpdateUpload" runat="server" />
        <asp:FileUpload runat="server" ID="ImageUpdateUpload" CssClass="btn" AllowMultiple="false" />

        <br />
        <br />

        <asp:Button Text="Update image" ID="UpdateImageSubmit" OnClick="UpdateImageSubmit_Click" runat="server" CssClass="btn btn-primary" />
    </div>
</asp:Content>
