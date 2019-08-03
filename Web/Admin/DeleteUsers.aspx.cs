using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Maticsoft.Common;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class DeleteUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int UserId = Convert.ToInt32(Context.Request.Params.Get("UserId"));
                if (new BLL.UsersBll().Delete(UserId))
                {
                    //Maticsoft.Common.MessageBox.ShowAndRedirect(this, "删除成功！", "Users.aspx");
                    //MessageBox.Show(this, "删除成功！");
                    //Response.Redirect("News.aspx");
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
            }
        }
    }
}