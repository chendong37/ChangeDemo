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
namespace Change.Web.Delivery
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int DeliveryID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(DeliveryID);
				}
			}
		}
			
	private void ShowInfo(int DeliveryID)
	{
		Change.BLL.Delivery bll=new Change.BLL.Delivery();
		Change.Model.Delivery model=bll.GetModel(DeliveryID);
		this.lblDeliveryID.Text=model.DeliveryID.ToString();
		this.txtUserId.Text=model.UserId.ToString();
		this.txtConsignee.Text=model.Consignee;
		this.txtComplete.Text=model.Complete;
		this.txtPhone.Text=model.Phone;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtUserId.Text))
			{
				strErr+="用户编号(外键)格式错误！\\n";	
			}
			if(this.txtConsignee.Text.Trim().Length==0)
			{
				strErr+="收件人姓名不能为空！\\n";	
			}
			if(this.txtComplete.Text.Trim().Length==0)
			{
				strErr+="详细地址不能为空！\\n";	
			}
			if(this.txtPhone.Text.Trim().Length==0)
			{
				strErr+="手机号不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int DeliveryID=int.Parse(this.lblDeliveryID.Text);
			int UserId=int.Parse(this.txtUserId.Text);
			string Consignee=this.txtConsignee.Text;
			string Complete=this.txtComplete.Text;
			string Phone=this.txtPhone.Text;


			Change.Model.Delivery model=new Change.Model.Delivery();
			model.DeliveryID=DeliveryID;
			model.UserId=UserId;
			model.Consignee=Consignee;
			model.Complete=Complete;
			model.Phone=Phone;

			Change.BLL.Delivery bll=new Change.BLL.Delivery();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
