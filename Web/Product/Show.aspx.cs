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
namespace Change.Web.Product
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
					int ProductId=(Convert.ToInt32(strid));
					ShowInfo(ProductId);
				}
			}
		}
		
	private void ShowInfo(int ProductId)
	{
		Change.BLL.Product bll=new Change.BLL.Product();
		Change.Model.Product model=bll.GetModel(ProductId);
		this.lblProductId.Text=model.ProductId.ToString();
		this.lblTitle.Text=model.Title;
		this.lblCateId.Text=model.CateId.ToString();
		this.lblMarketPrice.Text=model.MarketPrice.ToString();
		this.lblPrice.Text=model.Price.ToString();
		this.lblContent.Text=model.Content;
		this.lblPostTime.Text=model.PostTime.ToString();
		this.lblStock.Text=model.Stock.ToString();

	}


    }
}
