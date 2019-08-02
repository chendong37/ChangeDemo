using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class DeleteNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int newsId = Convert.ToInt32(Context.Request.Params.Get("newsId"));
            if (new BLL.NewsBll().Delete(newsId))
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "删除成功！", "News.aspx");
                //MessageBox.Show(this, "删除成功！");
                //Response.Redirect("News.aspx");
            }
        }
    }
}