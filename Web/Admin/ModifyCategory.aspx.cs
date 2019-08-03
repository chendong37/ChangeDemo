using Change.BLL;
using Change.Model;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class ModifyCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["BackUrl"] = Request.UrlReferrer.ToString();
                Session["CateId"] = Convert.ToInt32(Context.Request.Params.Get("CateId"));
                Session["ParentId"] = Convert.ToInt32(Context.Request.Params.Get("ParentId"));
                if ((int)Session["ParentId"]!=0)
                {
                    this.ParentId.DataSource = new CategoryBll().GetList("ParentId is Null");
                    this.ParentId.DataTextField = "CateName";
                    this.ParentId.DataValueField = "CateId";
                    this.ParentId.DataBind();
                    this.ParentId.SelectedValue = Session["ParentId"].ToString();
                    this.ParentId.Visible = true;
                }
                this.CateName.Text = Context.Request.Params.Get("CateName");
                
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.CateName.Text.Trim().Length == 0)
            {
                strErr += "类别名不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            string CateName = this.CateName.Text;

            Change.Model.CategoryModel model = new Change.Model.CategoryModel();
            model.CateId = Convert.ToInt32(Session["CateId"]);
            model.CateName = CateName;
            model.ParentId = Convert.ToInt32(this.ParentId.SelectedValue);
            Change.BLL.CategoryBll bll = new Change.BLL.CategoryBll();
            if (bll.Update(model))
            {
                MessageBox.Show(this, "修改成功！");
                Response.Redirect(ViewState["BackUrl"].ToString());
            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(ViewState["BackUrl"].ToString());
        }
    }
}