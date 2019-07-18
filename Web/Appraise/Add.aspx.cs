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
namespace Change.Web.Appraise
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtUserId.Text))
			{
				strErr+="用户编号(外键)格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtProductId.Text))
			{
				strErr+="商品编号(外键)格式错误！\\n";	
			}
			if(this.txtContent.Text.Trim().Length==0)
			{
				strErr+="评价内容不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtGrade.Text))
			{
				strErr+="评价等级：
0好评格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtRateTime.Text))
			{
				strErr+="评价时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int UserId=int.Parse(this.txtUserId.Text);
			int ProductId=int.Parse(this.txtProductId.Text);
			string Content=this.txtContent.Text;
			int Grade=int.Parse(this.txtGrade.Text);
			DateTime RateTime=DateTime.Parse(this.txtRateTime.Text);

			Change.Model.Appraise model=new Change.Model.Appraise();
			model.UserId=UserId;
			model.ProductId=ProductId;
			model.Content=Content;
			model.Grade=Grade;
			model.RateTime=RateTime;

			Change.BLL.Appraise bll=new Change.BLL.Appraise();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
