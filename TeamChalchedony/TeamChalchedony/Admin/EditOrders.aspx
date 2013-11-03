<%@ Page Title="Edit Order" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="EditOrders.aspx.cs"
    Inherits="TeamChalchedony.Admin.EditOrders" %>

<asp:Content ID="ContentEditOrders" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit orders</h1>
    <asp:GridView ID="GridViewOrders" runat="server" CssClass="table-bordered"
        ItemType="TeamChalchedony.Models.Order"
        AutoGenerateColumns="false"
        PageSize="10" AllowPaging="true" AllowSorting="true"
        SelectMethod="GridViewOrders_GetData">
        <Columns>
            <asp:TemplateField HeaderText="Customer">
                <ItemTemplate>
                    <asp:Label runat="server">
                        <%#: Item.Customer.FirstName + Item.Customer.LastName %>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="OrderDate" DataField="OrderDate" SortExpression="OrderDate" />
            <asp:BoundField HeaderText="Max Delivery Date" DataField="RequiredDate" />
            <asp:BoundField HeaderText="ShippedDate" DataField="ShippedDate" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Set as finished"
                        CssClass="btn btn-primary"
                        CommandArgument="<%#: Item.OrderID %>"
                        CommandName="FinishOrder"
                        OnCommand="OnButtonFinishOrder_Command" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
