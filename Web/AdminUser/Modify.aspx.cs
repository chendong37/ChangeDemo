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
namespace Change.Web.AdminUser
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int SuId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(SuId);
				}
			}
		}
			
	private void ShowInfo(int SuId)
	{
		Change.BLL.AdminUser bll=new Change.BLL.AdminUser();
		Change.Model.AdminUser model=bll.GetModel(SuId);
		this.lblSuId.Text=model.SuId.ToString();
		this.txtUserName.Text=model.UserName;
		this.txtPwd.Text=model.Pwd;
		this.txtrole.Text=model.role.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUserName.Text.Trim().Length==0)
			{
				strErr+="登录名不能为空！\\n";	
			}
			if(this.txtPwd.Text.Trim().Length==0)
			{
				strErr+="登录密码不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtrole.Text))
			{
				strErr+="0：普通管理员
1：超级管理格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int SuId=int.Parse(this.lblSuId.Text);
			string UserName=this.txtUserName.Text;
			string Pwd=this.txtPwd.Text;
			int role=int.Parse(this.txtrole.Text);


			Change.Model.AdminUser model=new Change.Model.AdminUser();
			model.SuId=SuId;
			model.UserName=UserName;
			model.Pwd=Pwd;
			model.role=role;

			Change.BLL.AdminUser bll=new Change.BLL.AdminUser();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
