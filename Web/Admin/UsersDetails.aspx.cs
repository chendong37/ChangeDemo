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
    public partial class UsersDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UsersModel model = new UsersModel();
                UsersBll bll = new UsersBll();
                int UserId = Convert.ToInt32(Context.Request.Params.Get("UserId"));
                model = bll.GetModel(UserId);
                
                this.txtUserName.Text = model.UserName;
                this.txtPwd.Text = model.Pwd;
                this.txtEmail.Text = model.Email;
                this.txtNick.Text = model.Nick;

            }
        }
    }
}