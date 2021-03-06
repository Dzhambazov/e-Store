﻿<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TeamChalchedony.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <p class="text-error">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <fieldset class="form-horizontal">
        <legend>Create a new account.</legend>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="control-label">User name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="UserName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-error" ErrorMessage="The user name field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="control-label">Password</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-error" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="control-label">Confirm password</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="control-label">First name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="FirstName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstName"
                    CssClass="text-error" ErrorMessage="The first name field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="LastName" CssClass="control-label">Last name</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="LastName" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastName"
                    CssClass="text-error" ErrorMessage="The last name field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="Address" CssClass="control-label">Address</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="Address" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Address"
                    CssClass="text-error" ErrorMessage="Address field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="City" CssClass="control-label">City</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="City" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="City"
                    CssClass="text-error" ErrorMessage="City field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="PostalCode" CssClass="control-label">Postal code</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="PostalCode" />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="Country" CssClass="control-label">Country</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="Country" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Country"
                    CssClass="text-error" ErrorMessage="Country field is required." />
            </div>
        </div>
        <div class="control-group">
            <asp:Label runat="server" AssociatedControlID="Phone" CssClass="control-label">Phone</asp:Label>
            <div class="controls">
                <asp:TextBox runat="server" ID="Phone" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Phone"
                    CssClass="text-error" ErrorMessage="Phone is required." />
            </div>
        </div>

        <div class="form-actions no-color">
            <asp:Button  runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn-success" />
        </div>
    </fieldset>

</asp:Content>
