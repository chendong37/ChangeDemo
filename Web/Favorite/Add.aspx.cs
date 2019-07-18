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
			if(!PageValidate.IsNumber(txtUserId.Text))
			{
				strErr+="用户编号(外键)格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ProductId=int.Parse(this.txtProductId.Text);
			int UserId=int.Parse(this.txtUserId.Text);

			Change.Model.Favorite model=new Change.Model.Favorite();
			model.ProductId=ProductId;
			model.UserId=UserId;

			Change.BLL.Favorite bll=new Change.BLL.Favorite();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
