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
namespace Change.Web.Delivery
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
					int DeliveryID=(Convert.ToInt32(strid));
					ShowInfo(DeliveryID);
				}
			}
		}
		
	private void ShowInfo(int DeliveryID)
	{
		Change.BLL.Delivery bll=new Change.BLL.Delivery();
		Change.Model.Delivery model=bll.GetModel(DeliveryID);
		this.lblDeliveryID.Text=model.DeliveryID.ToString();
		this.lblUserId.Text=model.UserId.ToString();
		this.lblConsignee.Text=model.Consignee;
		this.lblComplete.Text=model.Complete;
		this.lblPhone.Text=model.Phone;

	}


    }
}
