using Change.BLL;
using Change.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AdminUserBll bllAdminUser = new AdminUserBll();
                AdminUserModel loginAdminUser = new AdminUserModel();
                loginAdminUser.UserName = loginusername.Text;
                loginAdminUser.Pwd = loginuserpassword.Text;
                try
                {
                    loginAdminUser = bllAdminUser.GetModelLogin(loginAdminUser);
                    if (loginAdminUser.SuId!=0)
                    {
                        UserCustomValidator.IsValid = true;
                        Session["CurrentAdminUser"] = loginAdminUser;
                        Response.Redirect("./index.aspx");
                    }
                    else
                    {
                        UserCustomValidator.ErrorMessage = "用户名或密码错误！";
                        UserCustomValidator.IsValid = false;
                    }
                }
                catch (Exception)
                {
                    UserCustomValidator.ErrorMessage = "登陆异常！";
                    UserCustomValidator.IsValid = false;
                }
            }
        }

    }
}