using PollSystem.Controls.ErrorSuccessNotifier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamChalchedony.Models;

namespace TeamChalchedony.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        const string EMPTY_CATEGORY_VALUE = "NO_CAT";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }

            BindCategories();
        }

        private void BindCategories()
        {
            var context = new NorthwindEntities();
            var categories = (from category in context.Categories
                              select new
                              {
                                  Name = category.CategoryName,
                                  Id = category.CategoryID
                              }).ToList();
            //
            this.CategoryDropDown.DataSource = categories;
            this.CategoryDropDown.DataTextField = "Name";
            this.CategoryDropDown.DataValueField = "Id";
            this.CategoryDropDown.DataBind();


            this.CategoryDropDown.SelectedIndex = categories.Count;
        }

        protected void AddImage(ref Product product)
        {
            if (this.ImageUpdateUpload.HasFile)
            {
                product.Image = this.ImageUpdateUpload.FileBytes;
            }
            else
            {
                product.Image = File.ReadAllBytes(Server.MapPath("~/img/default-product.png"));
            }
        }

        protected void AddProductSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                bool error = false;
                var context = new NorthwindEntities();
                var product = new Product();

                string productName = this.ProductName.Text;
                if (productName == string.Empty)
                {
                    ErrorSuccessNotifier.AddErrorMessage("The 'Product name' field is required");
                    error = true;
                }
                else
                {
                    product.ProductName = productName;
                }

                string quantityPerUnit = this.QuantityPerUnit.Text;
                if (quantityPerUnit == string.Empty)
                {
                    ErrorSuccessNotifier.AddErrorMessage("The 'Quantity per unit' field is required");
                    error = true;
                }
                else
                {
                    product.QuantityPerUnit = quantityPerUnit;
                }

                if (this.UnitPrice.Text != string.Empty)
                {
                    try
                    {
                        decimal unitPrice = Convert.ToDecimal(this.UnitPrice.Text);
                        if (unitPrice < 0m)
                        {
                            ErrorSuccessNotifier.AddErrorMessage("The unit price must be a positive number");
                            error = true;
                        }

                        product.UnitPrice = unitPrice;
                    }
                    catch (FormatException fe)
                    {
                        ErrorSuccessNotifier.AddErrorMessage("Incorrect unit price. A number is required");
                        error = true;
                    }
                    catch (OverflowException ex)
                    {
                        ErrorSuccessNotifier.AddErrorMessage("Invalid unit price. The number is too big");
                        error = true;
                    }
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("The 'Unit price' field is required");
                    error = true;
                }

                if (this.UnitsInStock.Text != string.Empty)
                {
                    try
                    {
                        short unitsInStock = Convert.ToInt16(this.UnitsInStock.Text);
                        if (unitsInStock < 0)
                        {
                            ErrorSuccessNotifier.AddErrorMessage("The units in stock must be a positive number");
                            error = true;
                        }

                        product.UnitsInStock = unitsInStock;
                    }
                    catch (FormatException fe)
                    {
                        ErrorSuccessNotifier.AddErrorMessage("Incorrect Units in stock. A number is required");
                        error = true;
                    }
                    catch (OverflowException ex)
                    {
                        ErrorSuccessNotifier.AddErrorMessage("Invalid unit price. The number is too big");
                        error = true;
                    }
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("The 'Units in stock' field is required");
                    error = true;
                }

                // Display the errors
                if (error)
                {
                    return;
                }

                if (this.CategoryDropDown.SelectedValue != EMPTY_CATEGORY_VALUE)
                {
                    product.CategoryID = int.Parse(this.CategoryDropDown.SelectedValue);
                }
                else
                {
                    product.CategoryID = null;
                }

                AddImage(ref product);

                try
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                    return;
                }

                ErrorSuccessNotifier.AddSuccessMessage("Product added successfully");
                this.Response.Redirect("~/Default.aspx");
            }
        }
    }
}