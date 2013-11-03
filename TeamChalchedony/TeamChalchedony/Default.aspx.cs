using PollSystem.Controls.ErrorSuccessNotifier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamChalchedony.Models;

namespace TeamChalchedony
{
    public partial class _Default : Page
    {
        private readonly int productsOnMainPage = 5;
        const string LAST_SEARCH_QUERY = "LST_QRY";

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }

            var dbContext = new NorthwindEntities();
            var categories = dbContext.Categories.ToList();

            this.ListBoxCategories.DataSource = categories;
            this.ListBoxCategories.DataBind();
        }

        protected void ListBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Session["searched"] = false;
            this.GridViewProducts.SetPageIndex(0);
        }

        protected void GridViewProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //add css to GridViewrow based on rowState
                e.Row.CssClass = e.Row.RowState.ToString();
                //Add onclick attribute to select row.

                var productId = (e.Row.DataItem as Product).ProductID;

                //redirects to an edit product page if you are an administrator, order otherwise
                if (this.User.IsInRole("administrator"))
                {
                    e.Row.Attributes.Add("onclick", String.Format("javascript:window.location='Admin/EditSingleProduct.aspx?productId={0}'", productId));
                }
                else
                {
                    e.Row.Attributes.Add("onclick", String.Format("javascript:window.location='ProductPage.aspx?productId={0}'", productId));
                }
            }
        }

        public IQueryable<TeamChalchedony.Models.Product> GridViewProducts_GetData()
        {
            var dbContext = new NorthwindEntities();
            if (this.Session["searched"] != null && (bool)this.Session["searched"])
            {
                string searchedWord = this.Session[LAST_SEARCH_QUERY].ToString();

                if (searchedWord == string.Empty)
                {
                    return dbContext.Products;
                }
                else if (searchedWord.Length > 200)
                {
                    ErrorSuccessNotifier.AddErrorMessage("Too long query");
                    Response.Redirect("~/Default.aspx");
                    return null;
                }
                else
                {
                    var foundProducts = dbContext.Products.Where(p => p.ProductName.ToLower().Contains(searchedWord));
                    this.TextBoxSearchProducts.Value = "";
                    return foundProducts;
                }
            }
            else
            {
                if (this.ListBoxCategories.SelectedItem != null)
                {
                    int categoryId = Convert.ToInt32(this.ListBoxCategories.SelectedValue);
                    return dbContext.Products.Where(p => p.CategoryID == categoryId).OrderBy(p => p.ProductName);
                }
                else
                {
                    var productsCount = dbContext.Products.Count();
                    return dbContext.Products.OrderBy(p => p.ProductID)
                        .Skip(productsCount - productsOnMainPage).Take(productsOnMainPage);
                }
            }
        }

        protected void OnSearchButton_Click(object sender, EventArgs e)
        {
            this.Session[LAST_SEARCH_QUERY] = this.TextBoxSearchProducts.Value;
            this.Session["searched"] = true;
            this.GridViewProducts.SetPageIndex(0);
        }
    }
}