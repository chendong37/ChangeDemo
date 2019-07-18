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
namespace Change.Web.Category
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtCateName.Text.Trim().Length==0)
			{
				strErr+="类别名不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtParentId.Text))
			{
				strErr+="上级类别编号(外键)格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string CateName=this.txtCateName.Text;
			int ParentId=int.Parse(this.txtParentId.Text);

			Change.Model.Category model=new Change.Model.Category();
			model.CateName=CateName;
			model.ParentId=ParentId;

			Change.BLL.Category bll=new Change.BLL.Category();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
