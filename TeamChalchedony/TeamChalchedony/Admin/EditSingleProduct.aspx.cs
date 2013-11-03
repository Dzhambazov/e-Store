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
    public partial class EditProducts : System.Web.UI.Page
    {
        const string EMPTY_CATEGORY_VALUE = "NO_CAT";
        const string PRODUCT_ID_QUERY = "productId";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }

            BindProductData();
            this.DeleteDialog.Visible = false;
        }

        private void BindImage(byte[] image)
        {
            this.ProductImage.ImageUrl = GetImage(image);
        }

        private void BindProductData()
        {
            if (this.Request.QueryString[PRODUCT_ID_QUERY] == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Product not found.");
                this.Response.Redirect("~/Default.aspx");
            }

            var procurtId = Convert.ToInt32(this.Request.QueryString["productId"]);
            var context = new NorthwindEntities();

            var selectedProduct = (from product in context.Products
                                   where procurtId == product.ProductID
                                   select product).FirstOrDefault();

            if (selectedProduct == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Product not found.");
                this.Response.Redirect("~/Default.aspx");
            }

            BindImage(selectedProduct.Image);

            this.ProductName.Text = selectedProduct.ProductName;
            this.QuantityPerUnit.Text = selectedProduct.QuantityPerUnit;
            if (selectedProduct.UnitPrice != null)
            {
                this.UnitPrice.Text = string.Format("{0:f2}", selectedProduct.UnitPrice);
            }

            if (selectedProduct.UnitsInStock != null)
            {
                this.UnitsInStock.Text = selectedProduct.UnitsInStock.ToString();
            }

            BindCategories(selectedProduct);
        }

        private string GetImage(object img)
        {
            return "data:image/png;base64," + Convert.ToBase64String((byte[])img);
        }

        private void BindCategories(Product selectedProduct)
        {
            var context = new NorthwindEntities();
            var categories = (from category in context.Categories
                              select new
                              {
                                  Name = category.CategoryName,
                                  Id = category.CategoryID
                              }).ToList();

            this.CategoryDropDown.DataSource = categories;
            this.CategoryDropDown.DataTextField = "Name";
            this.CategoryDropDown.DataValueField = "Id";
            this.CategoryDropDown.DataBind();

            var emptyCategorySelector = new ListItem("None", EMPTY_CATEGORY_VALUE);
            this.CategoryDropDown.Items.Add(emptyCategorySelector);

            if (selectedProduct.CategoryID != null)
            {
                for (int i = 0; i < categories.Count; ++i)
                {
                    if (selectedProduct.CategoryID == categories[i].Id)
                    {
                        this.CategoryDropDown.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                this.CategoryDropDown.SelectedIndex = categories.Count;
            }
        }

        protected void EditProductSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                bool error = false;
                var procurtId = Convert.ToInt32(this.Request.QueryString["productId"]);
                var context = new NorthwindEntities();

                var selectedProduct = (from product in context.Products
                                       where procurtId == product.ProductID
                                       select product).FirstOrDefault();

                string productName = this.ProductName.Text;
                if (productName == string.Empty)
                {
                    ErrorSuccessNotifier.AddErrorMessage("The 'Product name' field is required");
                    error = true;
                }
                else
                {
                    selectedProduct.ProductName = productName;
                }

                string quantityPerUnit = QuantityPerUnit.Text;
                if (quantityPerUnit == string.Empty)
                {
                    ErrorSuccessNotifier.AddErrorMessage("The 'Quantity per unit' field is required");
                    error = true;
                }
                else
                {
                    selectedProduct.QuantityPerUnit = quantityPerUnit;
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

                        selectedProduct.UnitPrice = unitPrice;
                    }
                    catch (FormatException fe)
                    {
                        ErrorSuccessNotifier.AddErrorMessage("Invalid unit price. Number is required");
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

                        selectedProduct.UnitsInStock = unitsInStock;
                    }
                    catch (FormatException fe)
                    {
                        ErrorSuccessNotifier.AddErrorMessage("Invalid units in stock. Number is required");
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

                if (this.CategoryDropDown.SelectedValue != EMPTY_CATEGORY_VALUE)
                {
                    selectedProduct.CategoryID = int.Parse(this.CategoryDropDown.SelectedValue);
                }
                else
                {
                    selectedProduct.CategoryID = null;
                }

                try
                {
                    context.SaveChanges();
                    BindProductData();
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                    return;
                }

                ErrorSuccessNotifier.AddSuccessMessage("Product modified successfully");
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void UpdateImageSubmit_Click(object sender, EventArgs e)
        {
            if (this.ImageUpdateUpload.HasFile)
            {
                var procurtId = Convert.ToInt32(this.Request.QueryString[PRODUCT_ID_QUERY]);
                var context = new NorthwindEntities();

                var selectedProduct = (from product in context.Products
                                       where procurtId == product.ProductID
                                       select product).FirstOrDefault();

                selectedProduct.Image = this.ImageUpdateUpload.FileBytes;
                context.SaveChanges();

                BindImage(selectedProduct.Image);
            }
        }

        protected void DeleteProductButton_Click(object sender, EventArgs e)
        {
            this.DeleteDialog.Visible = true;
        }

        protected void ConfirmDelete_Click(object sender, EventArgs e)
        {
            var productId = Convert.ToInt32(this.Request.QueryString[PRODUCT_ID_QUERY]);

            try
            {
                var context = new NorthwindEntities();
                var selectedProduct = (from product in context.Products
                                       where product.ProductID == productId
                                       select product).FirstOrDefault();

                context.Products.Remove(selectedProduct);
                context.SaveChanges();
            }
            catch
            {
                ErrorSuccessNotifier.AddErrorMessage("An error occured during product deletion. Please try again lager.");
                this.Response.Redirect("~/Default.aspx");
            }

            ErrorSuccessNotifier.AddSuccessMessage("Product successfully deleted.");
            this.Response.Redirect("~/Default.aspx");
        }

        protected void CancelDelete_Click(object sender, EventArgs e)
        {
            this.DeleteDialog.Visible = false;
        }
    }
}