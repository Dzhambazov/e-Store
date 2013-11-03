<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TeamChalchedony._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<img id="Image" runat="server" />--%>

    <h1>Products Application</h1>

    <div id="custom-search-form" class="form-search form-horizontal pull-right">
        <div class="input-append span12">
            <input type="text" class="search-query" placeholder="Search" id="TextBoxSearchProducts" runat="server">
            <button type="submit" class="btn" onserverclick="OnSearchButton_Click" runat="server">
                <i class="icon-search"></i>
            </button>
        </div>
    </div>
    <br />
    <br />

    <%--<h2>Categories</h2>--%>
    <aside id="categories">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:ListBox ID="ListBoxCategories" runat="server"
                    AutoPostBack="true"
                    DataTextField="CategoryName"
                    DataValueField="CategoryID"
                    Rows="10"
                    OnSelectedIndexChanged="ListBoxCategories_SelectedIndexChanged"></asp:ListBox>
            </ContentTemplate>
        </asp:UpdatePanel>
    </aside>

    <%--<h2>Products</h2>--%>
    <div id="mainPageProductsContainer">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridViewProducts" runat="server"
                    ItemType="TeamChalchedony.Models.Product"
                    AutoGenerateColumns="false"
                    DataKeyNames="ProductID"
                    PageSize="5" AllowPaging="true"
                    OnRowDataBound="GridViewProducts_RowDataBound"
                    SelectMethod="GridViewProducts_GetData">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ImageUrl='<%#: "data:image/png;base64," + Convert.ToBase64String(Item.Image) %>' runat="server"
                                    Width="100" Height="100" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Product name" DataField="ProductName" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#: "$" + string.Format("{0:f2}",Item.UnitPrice) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <label id="test" runat="server"></label>
    </div>
</asp:Content>
