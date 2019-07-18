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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			int ProductId=int.Parse(this.txtProductId.Text);
			string PhotoUrl=this.txtPhotoUrl.Text;

			Change.Model.Photo model=new Change.Model.Photo();
			model.ProductId=ProductId;
			model.PhotoUrl=PhotoUrl;

			Change.BLL.Photo bll=new Change.BLL.Photo();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
