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
namespace Change.Web.Photo
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int PhotoId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(PhotoId);
				}
			}
		}
			
	private void ShowInfo(int PhotoId)
	{
		Change.BLL.Photo bll=new Change.BLL.Photo();
		Change.Model.Photo model=bll.GetModel(PhotoId);
		this.lblPhotoId.Text=model.PhotoId.ToString();
		this.txtProductId.Text=model.ProductId.ToString();
		this.txtPhotoUrl.Text=model.PhotoUrl;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtProductId.Text))
			{
				strErr+="商品编号(外键)格式错误！\\n";	
			}
			if(this.txtPhotoUrl.Text.Trim().Length==0)
			{
				strErr+="图片地址不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int PhotoId=int.Parse(this.lblPhotoId.Text);
			int ProductId=int.Parse(this.txtProductId.Text);
			string PhotoUrl=this.txtPhotoUrl.Text;


			Change.Model.Photo model=new Change.Model.Photo();
			model.PhotoId=PhotoId;
			model.ProductId=ProductId;
			model.PhotoUrl=PhotoUrl;

			Change.BLL.Photo bll=new Change.BLL.Photo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
