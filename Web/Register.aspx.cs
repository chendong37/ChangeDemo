using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Drawing;
using Change.Model;
using Change.BLL;
using Maticsoft.Common;

namespace Change.Web
{
    public partial class Register1 : System.Web.UI.Page
    {
        private bool UserNameIselgal = false;//用户名是否符合要求
        private bool PwdIselgal = false;//两次密码是否一致
        private bool EmailIselgal = false;//邮箱是否符合要求
        private bool CanRegister = false;//能注册？
        
 
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
 
 
        protected void linkToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        //待注册用户
        ModelUsers registerUser = new ModelUsers();
        //业务逻辑
        BllUsers userBll = new BllUsers();
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!CheckBox1.Checked)
            {
                Response.Write("<script>alert('服务条款未勾选!')</script>");
                return;
            }
            if (!UserNameIselgal || !PwdIselgal || !EmailIselgal)
                return;

            registerUser.UserName = rUserNameText.Text;
            registerUser.Pwd = rPwdText.Text;
            registerUser.Email = rEmailText.Text;
            registerUser.Nick = rNickText.Text == "" || rNickText.Text == "昵称" ? rUserNameText.Text : rNickText.Text;

            //检查是否重名
            try
            {
                if (userBll.ExistsUserName(registerUser.UserName))
                {

                    Response.Write("<script>alert('用户名已存在!')</script>");
                }
                else
                {
                    CanRegister = true;
                }
            }
            catch
            {
                Response.Write("检测重名异常");
            }
 
            finally
            {
               
            }
            //注册
            if (CanRegister)
            {
                try
                {
                    if (userBll.Add(registerUser)>0)
                    {
                        Session["CurrentUser"] = registerUser;
                        Response.Redirect("Home.aspx");
                    }
                   
                }
                catch
                {
                    Response.Write("注册异常");
                }
                finally
                {
                    
                }
            }
            
        }
 
        protected void CustomValidator1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (rUserNameText.Text.Equals("用户名"))
            {
                CustomValidator1.ErrorMessage = "*用户名为空";
                args.IsValid = false;
            } else if (System.Text.RegularExpressions.Regex.IsMatch(rUserNameText.Text, "^[0-9a-zA-Z]+$") &&
                    rUserNameText.Text.Length > 5 && rUserNameText.Text.Length < 11)
                    {
                    args.IsValid = true;
                    UserNameIselgal = true;
                    }
                 else
                {
                CustomValidator1.ErrorMessage = "*用户名由6~10位数字和字母构成";
                args.IsValid = false;
                 }
 
        }
 
        protected void CustomValidator2_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (rPwdText.Text.Equals("密码"))
            {
                CustomValidator2.ErrorMessage = "*密码为空";
                args.IsValid = false;
            }
 
            else if (System.Text.RegularExpressions.Regex.IsMatch(rPwdText.Text, "^[0-9a-zA-Z]+$") &&
              rPwdText.Text.Length > 4)
           {
                args.IsValid = true;
            }
            else
            {
                CustomValidator2.ErrorMessage = "*密码由全数字和字母构成且不少于5位";
                args.IsValid = false;
            }
        }
 
        protected void CustomValidator3_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (rrPwdText.Text.Equals("") ||rrPwdText.Text.Equals("确认密码"))
            {
                args.IsValid = false;
                CustomValidator3.ErrorMessage = "*确认密码为空";
            }
            else if (!rrPwdText.Text.Equals(rPwdText.Text))
            {
                args.IsValid = false;
                CustomValidator3.ErrorMessage = "*两次密码不一致";
            }
            else
            {
                PwdIselgal = true;
                args.IsValid = true;
            }
        }
        protected void CustomValidator4_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            if (rEmailText.Text.Equals("邮箱"))
            {
                CustomValidator4.ErrorMessage = "*邮箱为空";
                args.IsValid = false;
            }
            
            else if (PageValidate.IsEmail(rEmailText.Text))
            {
                args.IsValid = true;
                EmailIselgal = true;
            }
            else
            {
                args.IsValid = false;
                CustomValidator4.ErrorMessage = "*请输入正确的邮箱";
            }


        }
    }
}