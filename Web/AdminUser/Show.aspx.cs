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
namespace Change.Web.AdminUser
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
					int SuId=(Convert.ToInt32(strid));
					ShowInfo(SuId);
				}
			}
		}
		
	private void ShowInfo(int SuId)
	{
		Change.BLL.AdminUser bll=new Change.BLL.AdminUser();
		Change.Model.AdminUser model=bll.GetModel(SuId);
		this.lblSuId.Text=model.SuId.ToString();
		this.lblUserName.Text=model.UserName;
		this.lblPwd.Text=model.Pwd;
		this.lblrole.Text=model.role.ToString();

	}


    }
}
