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
namespace Change.Web.Category
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
					int CateId=(Convert.ToInt32(strid));
					ShowInfo(CateId);
				}
			}
		}
		
	private void ShowInfo(int CateId)
	{
		Change.BLL.Category bll=new Change.BLL.Category();
		Change.Model.Category model=bll.GetModel(CateId);
		this.lblCateId.Text=model.CateId.ToString();
		this.lblCateName.Text=model.CateName;
		this.lblParentId.Text=model.ParentId.ToString();

	}


    }
}
