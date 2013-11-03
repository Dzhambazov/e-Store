using PollSystem.Controls.ErrorSuccessNotifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamChalchedony.Models;

namespace TeamChalchedony.Admin
{
    public partial class EditOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<TeamChalchedony.Models.Order> GridViewOrders_GetData()
        {
            var dbContext = new NorthwindEntities();
            var orders = dbContext.Orders.Include("Customer").OrderByDescending(ord => ord.OrderDate);
            return orders;
        }

        protected void OnButtonFinishOrder_Command(object sender, CommandEventArgs e)
        {
            var dbContext = new NorthwindEntities();
            int orderId = Convert.ToInt32(e.CommandArgument);
            var order = dbContext.Orders.Find(orderId);

            if (order != null)
            {
                try
                {
                    if (order.ShippedDate == null)
                    {
                        order.ShippedDate = DateTime.Now;
                        dbContext.SaveChanges();

                        this.GridViewOrders.SetPageIndex(this.GridViewOrders.PageIndex);
                        ErrorSuccessNotifier.AddSuccessMessage("Order set as finished");
                    }
                    else
                    {
                        ErrorSuccessNotifier.AddWarningMessage("This order is already finished");
                    }
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("This order does not exist anymore. Please refresh the page");
            }
        }
    }
}