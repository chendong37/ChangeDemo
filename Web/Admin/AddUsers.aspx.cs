using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class AddUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtUserName.Text.Trim().Length == 0)
            {
                strErr += "用户名不能为空！\\n";
            }
            if (this.txtPwd.Text.Trim().Length == 0)
            {
                strErr += "密码不能为空！\\n";
            }
            if (this.txtEmail.Text.Trim().Length == 0)
            {
                strErr += "邮箱不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            string UserName = this.txtUserName.Text;
            string Pwd = this.txtPwd.Text;
            string Email = this.txtEmail.Text;
            string Nick = this.txtNick.Text;
            //DateTime PostTime = new DateTime();

            Change.Model.UsersModel model = new Change.Model.UsersModel();
            model.UserName = UserName;
            model.Pwd = Pwd;
            model.Email = Email;
            model.Nick = Nick;
            //model.PostTime = PostTime;

            Change.BLL.UsersBll bll = new Change.BLL.UsersBll();

            if (bll.Add(model) > 0)
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "Users.aspx");
                //MessageBox.Show(this, "保存成功！");
                //Response.Redirect("News.aspx");
            }
            else
            {
                MessageBox.Show(this, "保存失败！");
            }
        }
    }
}