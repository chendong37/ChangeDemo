using Change.Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] != null)
                btnToReg.Text = (Session["CurrentUser"] as UsersModel).Nick;
            //else
            //    Response.Redirect("login.aspx");
        }
 
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
 
        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}