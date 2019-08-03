using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class DeleteProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int productId = Convert.ToInt32(Context.Request.Params.Get("ProductId"));
                if (new BLL.ProductBll().Delete(productId))
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "删除成功！", "Product.aspx");
                    //MessageBox.Show(this, "删除成功！");
                    //Response.Redirect("News.aspx");
                }
            }
        }
    }
}