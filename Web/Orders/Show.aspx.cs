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
namespace Change.Web.Orders
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int OrdersID=(Convert.ToInt32(strid));
					ShowInfo(OrdersID);
				}
			}
		}
		
	private void ShowInfo(int OrdersID)
	{
		Change.BLL.Orders bll=new Change.BLL.Orders();
		Change.Model.Orders model=bll.GetModel(OrdersID);
		this.lblOrdersID.Text=model.OrdersID.ToString();
		this.lblOrderdate.Text=model.Orderdate.ToString();
		this.lblUserId.Text=model.UserId.ToString();
		this.lblTotal.Text=model.Total.ToString();
		this.lblDeliveryID.Text=model.DeliveryID.ToString();
		this.lblDeliveryDate.Text=model.DeliveryDate.ToString();
		this.lblStates.Text=model.States.ToString();
		this.lblRemark.Text=model.Remark;

	}


    }
}
