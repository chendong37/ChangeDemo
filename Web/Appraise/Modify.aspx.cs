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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int AppraiseId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(AppraiseId);
				}
			}
		}
			
	private void ShowInfo(int AppraiseId)
	{
		Change.BLL.Appraise bll=new Change.BLL.Appraise();
		Change.Model.Appraise model=bll.GetModel(AppraiseId);
		this.lblAppraiseId.Text=model.AppraiseId.ToString();
		this.txtUserId.Text=model.UserId.ToString();
		this.txtProductId.Text=model.ProductId.ToString();
		this.txtContent.Text=model.Content;
		this.txtGrade.Text=model.Grade.ToString();
		this.txtRateTime.Text=model.RateTime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int AppraiseId=int.Parse(this.lblAppraiseId.Text);
			int UserId=int.Parse(this.txtUserId.Text);
			int ProductId=int.Parse(this.txtProductId.Text);
			string Content=this.txtContent.Text;
			int Grade=int.Parse(this.txtGrade.Text);
			DateTime RateTime=DateTime.Parse(this.txtRateTime.Text);


			Change.Model.Appraise model=new Change.Model.Appraise();
			model.AppraiseId=AppraiseId;
			model.UserId=UserId;
			model.ProductId=ProductId;
			model.Content=Content;
			model.Grade=Grade;
			model.RateTime=RateTime;

			Change.BLL.Appraise bll=new Change.BLL.Appraise();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
