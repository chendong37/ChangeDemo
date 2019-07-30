using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Change.BLL;
using Change.Model;

namespace Change.Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
 
        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                UsersBll userBll = new UsersBll();
                UsersModel loginUser = new UsersModel();
                loginUser.UserName = TextBox1.Text;
                loginUser.Pwd = TextBox2.Text;
                loginUser = userBll.GetModelLogin(loginUser);
                if (loginUser.UserId!=0)
                {
                    Session["CurrentUser"] = loginUser;
                    Response.Redirect("./Home.aspx");
                }
                else
                {
                    Response.Write("<script>alert('用户名或密码错误')</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('登录异常')</script>");
            }
            finally
            {
            }
 
        }

    }
}