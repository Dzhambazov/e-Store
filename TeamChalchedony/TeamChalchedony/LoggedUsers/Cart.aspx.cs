using PollSystem.Controls.ErrorSuccessNotifier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamChalchedony.Models;

namespace TeamChalchedony.LoggedUsers
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                
            }
            var orders = this.Session["orders"] as List<Order>;

            this.ListViewOrders.DataSource = orders;
            this.ListViewOrders.DataBind();
            decimal totalSum = 0;

            if (orders != null && orders.Count != 0)
            {
                foreach (var order in orders)
                {
                    totalSum += 
                        (order.Order_Details.FirstOrDefault().UnitPrice *
                        order.Order_Details.FirstOrDefault().Quantity);
                }

                this.ProductsTotalSum.Text = Server.HtmlEncode(totalSum.ToString());
                this.ShipCountry.Text = Server.HtmlEncode(orders.FirstOrDefault().ShipCountry);
                this.ShipCity.Text = Server.HtmlEncode(orders.FirstOrDefault().ShipCity);
                this.ShipAddress.Text = Server.HtmlEncode(orders.FirstOrDefault().ShipAddress);
                this.RequiredDate.Text = Server.HtmlEncode(String.Format("{0:dd-MM-yyyy }", DateTime.Now.AddDays(14)));
            }
            else
            {
                this.ProductsTotalSum.Text = "";
                this.ShipCountry.Text = "";
                this.ShipCity.Text = "";
                this.ShipAddress.Text = "";
                this.RequiredDate.Text = "";
            }
        }

        protected void SubmitOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                var orders = this.Session["orders"] as List<Order>;
                if (orders == null || orders.Count == 0)
                {
                    ErrorSuccessNotifier.AddErrorMessage("You don't have any orders");
                    return;
                }

                foreach (var order in orders)
                {
                    var dbContext = new NorthwindEntities();
                    if (dbContext.Entry(order.Shipper).State == EntityState.Detached)
                    {
                        dbContext.Shippers.Attach(order.Shipper);
                    }

                    dbContext.Orders.Add(order);
                    dbContext.SaveChanges();
                }

                this.Session["orders"] = new List<Order>();
                ErrorSuccessNotifier.AddSuccessMessage("Order successfully checked out.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }
    }
}