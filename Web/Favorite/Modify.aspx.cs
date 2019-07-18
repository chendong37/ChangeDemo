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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Change.Web.Favorite
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int FavoriteID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(FavoriteID);
				}
			}
		}
			
	private void ShowInfo(int FavoriteID)
	{
		Change.BLL.Favorite bll=new Change.BLL.Favorite();
		Change.Model.Favorite model=bll.GetModel(FavoriteID);
		this.lblFavoriteID.Text=model.FavoriteID.ToString();
		this.txtProductId.Text=model.ProductId.ToString();
		this.txtUserId.Text=model.UserId.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtProductId.Text))
			{
				strErr+="商品编号(外键)格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtUserId.Text))
			{
				strErr+="用户编号(外键)格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int FavoriteID=int.Parse(this.lblFavoriteID.Text);
			int ProductId=int.Parse(this.txtProductId.Text);
			int UserId=int.Parse(this.txtUserId.Text);


			Change.Model.Favorite model=new Change.Model.Favorite();
			model.FavoriteID=FavoriteID;
			model.ProductId=ProductId;
			model.UserId=UserId;

			Change.BLL.Favorite bll=new Change.BLL.Favorite();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
