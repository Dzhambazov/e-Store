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
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewEdintCategiries_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<TeamChalchedony.Models.Category> GridViewEdintCategiries_GetData()
        {
            var context = new NorthwindEntities();
            return context.Categories;
        }

        protected void DeleteCategoryButton_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            using (var context = new NorthwindEntities())
            {
                Category category = context.Categories.FirstOrDefault(c => c.CategoryID == id);
                if (category.CategoryName == "Other")
                {
                    ErrorSuccessNotifier.AddErrorMessage("This Category Cannot be Deleted !");
                     this.Response.Redirect("~/Admin/EditCategories.aspx");
                }

                Category otherCategory = context.Categories.FirstOrDefault(c => c.CategoryName == "Other");
                foreach (var product in context.Products)
                {
                    if (product.Category == category)
                    {
                        product.Category = otherCategory;
                    }
                }
                context.Categories.Remove(category);
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Category successfully deleted!");
                this.Response.Redirect("~/Admin/EditCategories.aspx");
            }
        }

        protected void ShowAddCategoryPanel_Click(object sender, EventArgs e)
        {
            if (this.NewUserPanel.Visible == true)
            {
                this.NewUserPanel.Visible = false;
            }
            else
            {
                this.NewUserPanel.Visible = true;
            }
            this.EditUserPanel.Visible =  false;
        }

        protected void AddCategoryButton_Click(object sender, EventArgs e)
        {
            using (var context = new NorthwindEntities())
            {
                var categoryName = this.TextFieldNewUser.Text;
                if (categoryName.Length < 3 || categoryName.Length > 15)
                {
                    ErrorSuccessNotifier.AddErrorMessage("Category length should be  between 3 and 15 symbols");
                    this.Response.Redirect("~/Admin/EditCategories.aspx");
                }
                else
                {
                    context.Categories.Add(new Category { CategoryName = categoryName });
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage("Category has been successfully added!");
                    this.Response.Redirect("~/Admin/EditCategories.aspx");
                }
            }
        }

        protected void EditCategoriesPanelButton_Command(object sender, CommandEventArgs e)
        {
            Session["categoryOldName"] = e.CommandArgument.ToString();
            this.EditCategoryField.Text = e.CommandArgument.ToString();
            this.EditUserPanel.Visible = true;
            this.NewUserPanel.Visible = false;
        }

        protected void EditCategoryButton_Click(object sender, EventArgs e)
        {
            string oldCategoryName = Session["categoryOldName"].ToString();
            string newCategoryName = this.EditCategoryField.Text;

            if (newCategoryName.Length < 3 || newCategoryName.Length > 15)
            {
                ErrorSuccessNotifier.AddErrorMessage("Category length should be  between 3 and 15 symbols");
                this.Response.Redirect("~/Admin/EditCategories.aspx");
            }

            using (var context = new NorthwindEntities())
            {
                context.Categories.FirstOrDefault(c => c.CategoryName == oldCategoryName).CategoryName = newCategoryName;
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Category has been successufully updated!");
                this.Response.Redirect("~/Admin/EditCategories.aspx");
            }
        }
    }
}