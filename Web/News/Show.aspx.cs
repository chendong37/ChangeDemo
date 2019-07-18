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
namespace Change.Web.News
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
					int NewsID=(Convert.ToInt32(strid));
					ShowInfo(NewsID);
				}
			}
		}
		
	private void ShowInfo(int NewsID)
	{
		Change.BLL.News bll=new Change.BLL.News();
		Change.Model.News model=bll.GetModel(NewsID);
		this.lblNewsID.Text=model.NewsID.ToString();
		this.lblTitle.Text=model.Title;
		this.lblNTypes.Text=model.NTypes;
		this.lblContent.Text=model.Content;
		this.lblPhotoUrl.Text=model.PhotoUrl;
		this.lblPushTime.Text=model.PushTime.ToString();
		this.lblStates.Text=model.States.ToString();

	}


    }
}
