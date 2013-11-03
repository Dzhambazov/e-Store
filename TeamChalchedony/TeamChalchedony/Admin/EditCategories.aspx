<%@ Page Title="Edit Category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="TeamChalchedony.Admin.EditCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit categories</h1>
    <div id="EditCategoriesContainer">
                <asp:GridView ID="GridViewEdintCategiries" runat="server" AutoPostBack="true"
                    ItemType="TeamChalchedony.Models.Category"
                    AutoGenerateColumns="false"
                    DataKeyNames="CategoryID"
                    PageSize="5" AllowPaging="true"  
                    
                    SelectMethod="GridViewEdintCategiries_GetData">
                    <Columns>
                        <asp:BoundField HeaderText="Category" DataField="CategoryName" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button CssClass="btn btn-warning" ID="EditCategoriesPanelButton"  
                                    CommandArgument="<%#: Item.CategoryName %>" OnCommand="EditCategoriesPanelButton_Command" Text='<%#: "Edit"  %>' runat="server" />
                                <asp:Button CssClass="btn btn-danger" ID="DeleteCategoryButton" 
                                    CommandArgument="<%#: Item.CategoryID %>"  OnCommand="DeleteCategoryButton_Command" runat="server" Text='<%#: "Delete" %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

        <asp:Button CssClass="btn btn-info" id="ShowAddCategoryPanel" OnClick="ShowAddCategoryPanel_Click"  Text="Add New" runat="server"/>
        <asp:Panel ID="NewUserPanel" Visible="false" runat="server" >
            <asp:TextBox  Height="22px" ID="TextFieldNewUser" placeholder="Catehory Name" runat="server"></asp:TextBox>
            <asp:Button CssClass="btn btn-success" ID="AddCategoryButton" OnClick="AddCategoryButton_Click"  Text="Add" runat="server" />
        </asp:Panel>

         <asp:Panel ID="EditUserPanel"  Visible="false"  runat="server" >
             <asp:Label ID="EditCategoryOldCatName" runat="server"></asp:Label>
             <br />
            <asp:TextBox ID="EditCategoryField" placeholder="New Category Name" runat="server"></asp:TextBox>
            <asp:Button CssClass="btn btn-warning" ID="EditCategoryButton"  OnClick="EditCategoryButton_Click"   Text="Save" runat="server" />
        </asp:Panel>

    </div>
</asp:Content>
