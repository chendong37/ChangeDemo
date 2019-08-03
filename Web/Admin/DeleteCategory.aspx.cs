using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class DeleteCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["BackUrl"] = Request.UrlReferrer.ToString();
                int CateId = Convert.ToInt32(Context.Request.Params.Get("CateId"));
                string back = Context.Request.Params.Get("back");
                if (new BLL.CategoryBll().Delete(CateId))
                {
                    MessageBox.Show(this, "删除成功！");
                    Response.Redirect(ViewState["BackUrl"].ToString());
                }
            }
        }
    }
}