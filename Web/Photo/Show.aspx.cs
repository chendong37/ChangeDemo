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
namespace Change.Web.Photo
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
					int PhotoId=(Convert.ToInt32(strid));
					ShowInfo(PhotoId);
				}
			}
		}
		
	private void ShowInfo(int PhotoId)
	{
		Change.BLL.Photo bll=new Change.BLL.Photo();
		Change.Model.Photo model=bll.GetModel(PhotoId);
		this.lblPhotoId.Text=model.PhotoId.ToString();
		this.lblProductId.Text=model.ProductId.ToString();
		this.lblPhotoUrl.Text=model.PhotoUrl;

	}


    }
}
