using Change.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Masters
{
    public partial class AdminMasterPag : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentAdminUser"] != null)
            {
                adminUserName.Text = (Session["CurrentAdminUser"] as AdminUserModel).UserName;
            }
            else
                Response.Redirect("~/admin/Login.aspx");
        }
       
    }
}