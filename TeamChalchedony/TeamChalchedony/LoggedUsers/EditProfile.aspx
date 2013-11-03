<%@ Page Title="Edit Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditProfile.aspx.cs" Inherits="TeamChalchedony.LoggedUsers.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <fieldset class="form-horizontal">
            <legend>Edit your profile.</legend>

            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="FirstNameEdit" CssClass="control-label"><strong>First name</strong></asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="FirstNameEdit" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstNameEdit"
                        CssClass="text-error" ErrorMessage="The first name field is required." />
                </div>
            </div>
            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="LastNameEdit" CssClass="control-label"><strong>Last name</strong></asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="LastNameEdit" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="LastNameEdit"
                        CssClass="text-error" ErrorMessage="The last name field is required." />
                </div>
            </div>
            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="AddressEdit" CssClass="control-label"><strong>Address</strong></asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="AddressEdit" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="AddressEdit"
                        CssClass="text-error" ErrorMessage="The Address field is required." />
                </div>
            </div>
            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="CityEdit" CssClass="control-label"><strong>City</strong></asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="CityEdit" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="CityEdit"
                        CssClass="text-error" ErrorMessage="The city field is required." />
                </div>
            </div>
            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="PostalCodeEdit" CssClass="control-label"><strong>Postal code</strong></asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="PostalCodeEdit" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="CountryEdit" CssClass="control-label"><strong>Country</strong></asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="CountryEdit" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="CountryEdit"
                        CssClass="text-error" ErrorMessage="The postal code field is required." />
                </div>
            </div>
            <div class="control-group">
                <asp:Label runat="server" AssociatedControlID="PhoneEdit" CssClass="control-label"><strong>Phone</strong></asp:Label>
                <div class="controls">
                    <asp:TextBox runat="server" ID="PhoneEdit" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneEdit"
                        CssClass="text-error" ErrorMessage="The phone field is required." />
                </div>
            </div>
            <div>
                <asp:Button Text="Confirm Changes" CssClass="btn btn-primary" OnClick="SaveChanges_Click" runat="server" />
                <asp:Button Text="Cancel Changes" CssClass="btn btn-primary" OnClick="CancelChanges_Click" runat="server" />
            </div>
        </fieldset>
    </div>
</asp:Content>
