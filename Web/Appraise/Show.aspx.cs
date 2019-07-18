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
namespace Change.Web.Appraise
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
					int AppraiseId=(Convert.ToInt32(strid));
					ShowInfo(AppraiseId);
				}
			}
		}
		
	private void ShowInfo(int AppraiseId)
	{
		Change.BLL.Appraise bll=new Change.BLL.Appraise();
		Change.Model.Appraise model=bll.GetModel(AppraiseId);
		this.lblAppraiseId.Text=model.AppraiseId.ToString();
		this.lblUserId.Text=model.UserId.ToString();
		this.lblProductId.Text=model.ProductId.ToString();
		this.lblContent.Text=model.Content;
		this.lblGrade.Text=model.Grade.ToString();
		this.lblRateTime.Text=model.RateTime.ToString();

	}


    }
}
