using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using TeamChalchedony.Models;
using PollSystem.Controls.ErrorSuccessNotifier;
using System.Text.RegularExpressions;

namespace TeamChalchedony.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            using (var tran = new TransactionScope())
            {
                if (!IsValidUser())
                {
                    return;
                }
                var customer = new Customer()
                {
                    FirstName = this.FirstName.Text,
                    LastName = this.LastName.Text,
                    Address = this.Address.Text,
                    City = this.City.Text,
                    PostalCode = this.PostalCode.Text,
                    Country = this.Country.Text,
                    Phone = this.Phone.Text
                };

                var dbContext = new NorthwindEntities();
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();

                string userName = UserName.Text;
                var manager = new AuthenticationIdentityManager(new IdentityStore(new ApplicationDbContext()));
                ApplicationUser u = new ApplicationUser() { UserName = userName, CustomerId = customer.CustomerId };
                IdentityResult result = manager.Users.CreateLocalUser(u, Password.Text);
                if (result.Success)
                {
                    tran.Complete();
                    manager.Authentication.SignIn(Context.GetOwinContext().Authentication, u.Id, isPersistent: false);
                    OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                }
            }
        }

        private bool IsValidUser()
        {
            bool anyError = false;
            if (this.FirstName.Text.Length < 4 || this.FirstName.Text.Length > 15)
            {
                ErrorSuccessNotifier.AddErrorMessage("First name length should be  between 4 and 15 symbols");
                anyError = true;
            }

            if (this.LastName.Text.Length < 4 || this.LastName.Text.Length > 15)
            {
                ErrorSuccessNotifier.AddErrorMessage("Last name length should be  between 4 and 15 symbols");
                anyError = true;

            }

            if (this.Address.Text.Length < 4 || this.Address.Text.Length > 15)
            {
                ErrorSuccessNotifier.AddErrorMessage("Address length should be  between 4 and 15 symbols");
                anyError = true;

            }

            if (this.City.Text.Length < 4 || this.City.Text.Length > 15)
            {
                ErrorSuccessNotifier.AddErrorMessage("Cinty length should be  between 4 and 15 symbols");
                anyError = true;

            }

            if (this.Country.Text.Length < 4 || this.Country.Text.Length > 15)
            {
                ErrorSuccessNotifier.AddErrorMessage("Address length should be  between 4 and 15 symbols");
                anyError = true;

            }

            Regex regex = new Regex(@"[0-9]+");
            bool isPhoneCorrect = regex.IsMatch(this.Phone.Text);

            if (!isPhoneCorrect)
            {
                ErrorSuccessNotifier.AddErrorMessage("Wrong phone number");
                this.Response.Redirect("~/Account/Register.aspx");
            }

            if (anyError)
            {
                return false;
            }
            return true;
        }
    }
}