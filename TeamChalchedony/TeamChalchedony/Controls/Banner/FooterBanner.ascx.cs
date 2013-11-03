using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeamChalchedony.Controls.Banner
{
    public partial class FooterBanner : System.Web.UI.UserControl
    {
        public string NavigateUrl { get; set; }

        public string ImageUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ImageBanner.ImageUrl = this.ImageUrl;
            this.HyperLinkBanner.NavigateUrl = this.NavigateUrl;
        }
    }
}