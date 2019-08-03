using Change.BLL;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class CategoryChild : System.Web.UI.Page
    {
        CategoryBll categoryBll = new CategoryBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //管理子类

                Session["ParentId"] = Convert.ToInt32(Context.Request.Params.Get("CateId"));
                Session["ParentName"] = Context.Request.Params.Get("CateName");
                int ParentId = (int)Session["ParentId"];
                Page.DataBind();
                if (ParentId != 0)
                {
                    DataSet ds = categoryBll.GetList("ParentId=" + ParentId);
                    this.CategoryRepeater1.DataSource = ds;
                    this.CategoryRepeater1.DataBind();
                }
            }
        }
        protected void AddCategory_Click(object sender, EventArgs e)
        {
            this.NewCateName.Visible = true;
            this.btnCancle.Visible = true;
            this.btn_addCateName.Visible = true;
        }
        protected void btn_addCateName_Click(object sender, EventArgs e)
        {
            int ParentId = (int)Session["ParentId"];
            string strErr = "";
            if (this.NewCateName.Text.Trim().Length == 0)
            {
                strErr += "类别名不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            string CateName = this.NewCateName.Text;

            Change.Model.CategoryModel model = new Change.Model.CategoryModel();
            model.CateName = CateName;
            model.ParentId = ParentId;

            Change.BLL.CategoryBll bll = new Change.BLL.CategoryBll();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "添加成功！", "CategoryChild.aspx?CateId="+ Session["ParentId"] + "&CateName="+ Session["ParentName"]);
        }
        public void btnCancle_Click(object sender, EventArgs e)
        {
            this.NewCateName.Visible = false;
            this.btnCancle.Visible = false;
            this.btn_addCateName.Visible = false;
        }
    }
}