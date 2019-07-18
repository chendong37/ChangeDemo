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
namespace Change.Web.OrdersDetail
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
					int DetailID=(Convert.ToInt32(strid));
					ShowInfo(DetailID);
				}
			}
		}
		
	private void ShowInfo(int DetailID)
	{
		Change.BLL.OrdersDetail bll=new Change.BLL.OrdersDetail();
		Change.Model.OrdersDetail model=bll.GetModel(DetailID);
		this.lblDetailID.Text=model.DetailID.ToString();
		this.lblOrdersID.Text=model.OrdersID.ToString();
		this.lblProductId.Text=model.ProductId.ToString();
		this.lblQuantity.Text=model.Quantity.ToString();
		this.lblStates.Text=model.States.ToString();

	}


    }
}
