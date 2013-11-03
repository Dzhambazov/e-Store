using PollSystem.Controls.ErrorSuccessNotifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamChalchedony.Models;

namespace TeamChalchedony
{
    public partial class ProductPage : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }

            var dbContext = new NorthwindEntities();
            int productId = Convert.ToInt32(this.Request.Params["productId"]);
            var product = dbContext.Products.Find(productId);

            if (product != null)
            {
                this.LabelProductName.Text = Server.HtmlEncode(product.ProductName);
                this.LabelQuantityPerUnit.Text = Server.HtmlEncode(product.QuantityPerUnit);
                //this.LabelSupplierName.Text = Server.HtmlEncode(product.Supplier.CompanyName);
                this.LabelUnitPrice.Text = Server.HtmlEncode(string.Format("${0:f2}", product.UnitPrice));
                this.LabelUnitsInStock.Text = Server.HtmlEncode(product.UnitsInStock.ToString());
                this.TextBoxQuantity.Attributes.Add("min", "1");
                this.TextBoxQuantity.Attributes.Add("max", product.UnitsInStock.ToString());
                this.TextBoxQuantity.Text = "1";
                this.ProductImage.Src = "data:image/png;base64," + Convert.ToBase64String(product.Image);
            }

            if (!User.Identity.IsAuthenticated || product.UnitsInStock == 0)
            {
                this.PanelProduct.Controls.Remove(this.TextBoxQuantity);
                this.PanelProduct.Controls.Remove(this.ButtonAddToCart);
            }

            var shippers = dbContext.Shippers.ToList();
            this.DropDownShippers.DataSource = shippers;
            this.DropDownShippers.DataBind();
        }

        protected void OnButtonAddToCart_Click(object sender, EventArgs e)
        {
            using (var dbContext = new NorthwindEntities())
            {
                int productId = Convert.ToInt32(this.Request.Params["productId"]);
                var product = dbContext.Products.Find(productId);
                var currUser = dbContext.AspNetUsers
                    .FirstOrDefault(usr => usr.UserName.ToLower() == User.Identity.Name.ToLower());

                var currCustomer = dbContext.Customers.Find(currUser.CustomerId);
                var shipName = currCustomer.FirstName + currCustomer.LastName;

                if (product != null)
                {
                    product.UnitsInStock -= short.Parse(this.TextBoxQuantity.Text);
                    dbContext.SaveChanges();

                    var orderDetails = new Order_Detail()
                    {
                        Product = product,
                        UnitPrice = decimal.Parse(product.UnitPrice.ToString()),
                        Quantity = short.Parse(this.TextBoxQuantity.Text),
                        Discount = 0
                    };

                    int shipperId = Convert.ToInt32(this.DropDownShippers.SelectedValue);
                    var shipper = dbContext.Shippers.FirstOrDefault(sh => sh.ShipperID == shipperId);

                    var order = new Order()
                    {
                        Customer = currCustomer,
                        OrderDate = DateTime.Now,
                        RequiredDate = DateTime.Now.AddDays(14),
                        ShipAddress = currCustomer.Address,
                        ShipCity = currCustomer.City,
                        ShipCountry = currCustomer.Country,
                        ShipName = shipName,
                        Shipper = shipper,
                        ShipPostalCode = currCustomer.PostalCode
                    };

                    order.Order_Details.Add(orderDetails);

                    if (this.Session["orders"] == null)
                    {
                        this.Session["orders"] = new List<Order>();
                    }

                    (this.Session["orders"] as List<Order>).Add(order);
                    ErrorSuccessNotifier.AddSuccessMessage("Order added to Cart");
                    this.Response.Redirect("~/LoggedUsers/Cart.aspx");
                }
            }
        }
    }
}