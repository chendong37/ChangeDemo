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

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            this.LabelClock.Text = new DateTime().ToLongTimeString();
            this.LabelClock.Text = DateTime.Now.ToString("T");
            this.LabelClock.ToolTip = DateTime.Today.ToString("yyyy-MM-dd  HH:mm:ss");


        }
    }
}