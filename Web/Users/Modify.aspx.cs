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
namespace Change.Web.Users
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int UserId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(UserId);
				}
			}
		}
			
	private void ShowInfo(int UserId)
	{
		Change.BLL.Users bll=new Change.BLL.Users();
		Change.Model.Users model=bll.GetModel(UserId);
		this.lblUserId.Text=model.UserId.ToString();
		this.txtUserName.Text=model.UserName;
		this.txtPwd.Text=model.Pwd;
		this.txtEmail.Text=model.Email;
		this.txtNick.Text=model.Nick;
		this.txtDeliveryID.Text=model.DeliveryID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUserName.Text.Trim().Length==0)
			{
				strErr+="用户登录名不能为空！\\n";	
			}
			if(this.txtPwd.Text.Trim().Length==0)
			{
				strErr+="用户密码不能为空！\\n";	
			}
			if(this.txtEmail.Text.Trim().Length==0)
			{
				strErr+="邮箱不能为空！\\n";	
			}
			if(this.txtNick.Text.Trim().Length==0)
			{
				strErr+="昵称不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtDeliveryID.Text))
			{
				strErr+="默认收货地址编号(外键)格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int UserId=int.Parse(this.lblUserId.Text);
			string UserName=this.txtUserName.Text;
			string Pwd=this.txtPwd.Text;
			string Email=this.txtEmail.Text;
			string Nick=this.txtNick.Text;
			int DeliveryID=int.Parse(this.txtDeliveryID.Text);


			Change.Model.Users model=new Change.Model.Users();
			model.UserId=UserId;
			model.UserName=UserName;
			model.Pwd=Pwd;
			model.Email=Email;
			model.Nick=Nick;
			model.DeliveryID=DeliveryID;

			Change.BLL.Users bll=new Change.BLL.Users();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
