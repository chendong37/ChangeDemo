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
namespace Change.Web.OrdersDetail
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int DetailID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(DetailID);
				}
			}
		}
			
	private void ShowInfo(int DetailID)
	{
		Change.BLL.OrdersDetail bll=new Change.BLL.OrdersDetail();
		Change.Model.OrdersDetail model=bll.GetModel(DetailID);
		this.lblDetailID.Text=model.DetailID.ToString();
		this.txtOrdersID.Text=model.OrdersID.ToString();
		this.txtProductId.Text=model.ProductId.ToString();
		this.txtQuantity.Text=model.Quantity.ToString();
		this.txtStates.Text=model.States.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtOrdersID.Text))
			{
				strErr+="订单编号(外键)格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtProductId.Text))
			{
				strErr+="商品编号(外键)格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtQuantity.Text))
			{
				strErr+="商品数量格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtStates.Text))
			{
				strErr+="明细状态：0正常格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int DetailID=int.Parse(this.lblDetailID.Text);
			int OrdersID=int.Parse(this.txtOrdersID.Text);
			int ProductId=int.Parse(this.txtProductId.Text);
			int Quantity=int.Parse(this.txtQuantity.Text);
			int States=int.Parse(this.txtStates.Text);


			Change.Model.OrdersDetail model=new Change.Model.OrdersDetail();
			model.DetailID=DetailID;
			model.OrdersID=OrdersID;
			model.ProductId=ProductId;
			model.Quantity=Quantity;
			model.States=States;

			Change.BLL.OrdersDetail bll=new Change.BLL.OrdersDetail();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
