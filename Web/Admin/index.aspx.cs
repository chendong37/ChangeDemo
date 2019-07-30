using Change.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentAdminUser"] != null)
                aUserInfo.Text = (Session["CurrentAdminUser"] as AdminUserModel).UserName;
            else
                Response.Redirect("Login.aspx");
        }
    }
}