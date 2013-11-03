using PollSystem.Controls.ErrorSuccessNotifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamChalchedony.Models;

namespace TeamChalchedony.LoggedUsers
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                if (!Page.IsPostBack)
                {
                    var dbContext = new NorthwindEntities();
                    var name = Page.User.Identity.Name;
                    var currUser = dbContext.AspNetUsers
                            .FirstOrDefault(usr => usr.UserName.ToLower() == User.Identity.Name.ToLower());
                    var currCustomer = dbContext.Customers.Find(currUser.CustomerId);


                    this.FirstNameEdit.Text = currCustomer.FirstName;
                    this.LastNameEdit.Text = currCustomer.LastName;

                    this.AddressEdit.Text = currCustomer.Address;
                    this.CityEdit.Text = currCustomer.City;
                    this.PostalCodeEdit.Text = currCustomer.PostalCode;
                    this.CountryEdit.Text = currCustomer.Country;
                    this.PhoneEdit.Text = currCustomer.Phone;
                    this.DataBind();

                }
            }
        }

        protected void SaveChanges_Click(object sender, EventArgs e)
        {
            var dbContext = new NorthwindEntities();
            var name = Page.User.Identity.Name;
            var currUser = dbContext.AspNetUsers
                    .FirstOrDefault(usr => usr.UserName.ToLower() == User.Identity.Name.ToLower());
            var currCustomer = dbContext.Customers.Find(currUser.CustomerId);

            bool error = false;

            if (this.FirstNameEdit.Text.Length < 30)
            {
                currCustomer.FirstName = this.FirstNameEdit.Text;
            }
            else
            {
                error = true;
                ErrorSuccessNotifier.AddErrorMessage("Your first name must be less than 30 charachters");
            }


            if (this.LastNameEdit.Text.Length < 30)
            {
                currCustomer.LastName = this.LastNameEdit.Text;
            }
            else
            {
                error = true;
                ErrorSuccessNotifier.AddErrorMessage("Your last name must be less than 30 charachters");
            }

            if (this.AddressEdit.Text.Length < 60)
            {
                currCustomer.Address = this.AddressEdit.Text;
            }
            else
            {
                error = true;
                ErrorSuccessNotifier.AddErrorMessage("Your address must be less than 60 charachters");
            }

            if (this.CityEdit.Text.Length < 15)
            {
                currCustomer.City = this.CityEdit.Text;
            }
            else
            {
                error = true;
                ErrorSuccessNotifier.AddErrorMessage("Your city must be less than 15 charachters");
            }

            if (this.PostalCodeEdit.Text.Length < 10)
            {
                currCustomer.PostalCode = this.PostalCodeEdit.Text;
            }
            else
            {
                error = true;
                ErrorSuccessNotifier.AddErrorMessage("Your postal code must be less than 10 charachters");
            }

            if (this.CountryEdit.Text.Length < 15)
            {
                currCustomer.Country = this.CountryEdit.Text;
            }
            else
            {
                error = true;
                ErrorSuccessNotifier.AddErrorMessage("Your country name must be less than 15 charachters");
            }

            if (this.PhoneEdit.Text.Length < 24)
            {
                currCustomer.Phone = this.PhoneEdit.Text;
            }
            else
            {
                error = true;
                ErrorSuccessNotifier.AddErrorMessage("Your phone number must be less than 24 charachters");
            }

            if (!error)
            {
                dbContext.SaveChanges();
                this.DataBind();
                ErrorSuccessNotifier.AddSuccessMessage("Your Profile has been updated successfully");
                this.Response.Redirect("~/Account/Manage.aspx");
            }

        }

        protected void CancelChanges_Click(object sender, EventArgs e)
        {

            ErrorSuccessNotifier.AddInfoMessage("Your profile was not edited!");
            this.Response.Redirect("~/Account/Manage.aspx");

        }
    }
}