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
namespace Change.Web.Users
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
					int UserId=(Convert.ToInt32(strid));
					ShowInfo(UserId);
				}
			}
		}
		
	private void ShowInfo(int UserId)
	{
		Change.BLL.Users bll=new Change.BLL.Users();
		Change.Model.Users model=bll.GetModel(UserId);
		this.lblUserId.Text=model.UserId.ToString();
		this.lblUserName.Text=model.UserName;
		this.lblPwd.Text=model.Pwd;
		this.lblEmail.Text=model.Email;
		this.lblNick.Text=model.Nick;
		this.lblDeliveryID.Text=model.DeliveryID.ToString();

	}


    }
}
