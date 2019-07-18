using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Change.Web.Category
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int CateId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(CateId);
				}
			}
		}
			
	private void ShowInfo(int CateId)
	{
		Change.BLL.Category bll=new Change.BLL.Category();
		Change.Model.Category model=bll.GetModel(CateId);
		this.lblCateId.Text=model.CateId.ToString();
		this.txtCateName.Text=model.CateName;
		this.txtParentId.Text=model.ParentId.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtCateName.Text.Trim().Length==0)
			{
				strErr+="类别名不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtParentId.Text))
			{
				strErr+="上级类别编号(外键)格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int CateId=int.Parse(this.lblCateId.Text);
			string CateName=this.txtCateName.Text;
			int ParentId=int.Parse(this.txtParentId.Text);


			Change.Model.Category model=new Change.Model.Category();
			model.CateId=CateId;
			model.CateName=CateName;
			model.ParentId=ParentId;

			Change.BLL.Category bll=new Change.BLL.Category();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
