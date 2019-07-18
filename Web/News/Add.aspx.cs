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
namespace Change.Web.News
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtTitle.Text.Trim().Length==0)
			{
				strErr+="标题不能为空！\\n";	
			}
			if(this.txtNTypes.Text.Trim().Length==0)
			{
				strErr+="分类不能为空！\\n";	
			}
			if(this.txtContent.Text.Trim().Length==0)
			{
				strErr+="内容不能为空！\\n";	
			}
			if(this.txtPhotoUrl.Text.Trim().Length==0)
			{
				strErr+="图片地址不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtPushTime.Text))
			{
				strErr+="发布时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtStates.Text))
			{
				strErr+="消息状态：0置顶格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Title=this.txtTitle.Text;
			string NTypes=this.txtNTypes.Text;
			string Content=this.txtContent.Text;
			string PhotoUrl=this.txtPhotoUrl.Text;
			DateTime PushTime=DateTime.Parse(this.txtPushTime.Text);
			int States=int.Parse(this.txtStates.Text);

			Change.Model.News model=new Change.Model.News();
			model.Title=Title;
			model.NTypes=NTypes;
			model.Content=Content;
			model.PhotoUrl=PhotoUrl;
			model.PushTime=PushTime;
			model.States=States;

			Change.BLL.News bll=new Change.BLL.News();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
