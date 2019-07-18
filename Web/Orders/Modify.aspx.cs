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
namespace Change.Web.Orders
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int OrdersID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(OrdersID);
				}
			}
		}
			
	private void ShowInfo(int OrdersID)
	{
		Change.BLL.Orders bll=new Change.BLL.Orders();
		Change.Model.Orders model=bll.GetModel(OrdersID);
		this.lblOrdersID.Text=model.OrdersID.ToString();
		this.txtOrderdate.Text=model.Orderdate.ToString();
		this.txtUserId.Text=model.UserId.ToString();
		this.txtTotal.Text=model.Total.ToString();
		this.txtDeliveryID.Text=model.DeliveryID.ToString();
		this.txtDeliveryDate.Text=model.DeliveryDate.ToString();
		this.txtStates.Text=model.States.ToString();
		this.txtRemark.Text=model.Remark;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtOrderdate.Text))
			{
				strErr+="下单时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtUserId.Text))
			{
				strErr+="用户编号(外键)格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtTotal.Text))
			{
				strErr+="订单总价格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtDeliveryID.Text))
			{
				strErr+="用户收货地址编号(外键)格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtDeliveryDate.Text))
			{
				strErr+="收货日期格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtStates.Text))
			{
				strErr+="订单状态：
0未付款格式错误！\\n";	
			}
			if(this.txtRemark.Text.Trim().Length==0)
			{
				strErr+="备注不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int OrdersID=int.Parse(this.lblOrdersID.Text);
			DateTime Orderdate=DateTime.Parse(this.txtOrderdate.Text);
			int UserId=int.Parse(this.txtUserId.Text);
			decimal Total=decimal.Parse(this.txtTotal.Text);
			int DeliveryID=int.Parse(this.txtDeliveryID.Text);
			DateTime DeliveryDate=DateTime.Parse(this.txtDeliveryDate.Text);
			int States=int.Parse(this.txtStates.Text);
			string Remark=this.txtRemark.Text;


			Change.Model.Orders model=new Change.Model.Orders();
			model.OrdersID=OrdersID;
			model.Orderdate=Orderdate;
			model.UserId=UserId;
			model.Total=Total;
			model.DeliveryID=DeliveryID;
			model.DeliveryDate=DeliveryDate;
			model.States=States;
			model.Remark=Remark;

			Change.BLL.Orders bll=new Change.BLL.Orders();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
