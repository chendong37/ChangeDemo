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
namespace Change.Web.Favorite
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
					int FavoriteID=(Convert.ToInt32(strid));
					ShowInfo(FavoriteID);
				}
			}
		}
		
	private void ShowInfo(int FavoriteID)
	{
		Change.BLL.Favorite bll=new Change.BLL.Favorite();
		Change.Model.Favorite model=bll.GetModel(FavoriteID);
		this.lblFavoriteID.Text=model.FavoriteID.ToString();
		this.lblProductId.Text=model.ProductId.ToString();
		this.lblUserId.Text=model.UserId.ToString();

	}


    }
}
