using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtTitle.Text.Trim().Length == 0)
            {
                strErr += "标题不能为空！\\n";
            }
            if (this.txtNTypes.Text.Trim().Length == 0)
            {
                strErr += "分类不能为空！\\n";
            }
            if (this.txtContentVal.Text.Trim().Length == 0)
            {
                strErr += "内容不能为空！\\n";
            }
            if (this.txtPhotoUrl.FileName.Trim().Length == 0)
            {
                strErr += "图片地址不能为空！\\n";
            }
            if (!PageValidate.IsDateTime(txtPushTime.Value))
            {
                strErr += "发布时间格式错误！\\n";
            }
            
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            string Title = this.txtTitle.Text;
            string NTypes = this.txtNTypes.Text;
            string Content = this.txtContentVal.Text; 
            string PhotoUrl = this.txtPhotoUrl.FileName;
            DateTime PushTime = DateTime.Parse(this.txtPushTime.Value);
            int States = 0;//置顶
            if (this.txtStates1.Checked)
                States = 1;

            //上传商品图片
            //判断是否存在上传的文件
            if (this.txtPhotoUrl.HasFile == false)
            {
                ClientScript.RegisterStartupScript(
                    this.GetType(), "error", "alert('未选择任何文件！');", true);
                return;
            }
            //获取文件的后缀名
            string temp = this.txtPhotoUrl.FileName.Substring(this.txtPhotoUrl.FileName.LastIndexOf('.') + 1).ToLower();
            //判断是否为图片文件
            if (temp != "bmp" && temp != "jpg" && temp != "png")
            {
                ClientScript.RegisterStartupScript(
                 this.GetType(), "error", "alert('只能上传图片文件！');", true);
                return;
            }
            //为了防止不同用户上传图片重名，为文件进行重命名
            string newFileName = DateTime.Now.Ticks + "." + temp;
            //保存文件
            this.txtPhotoUrl.SaveAs(Server.MapPath("/") + "UploadFiles/" + newFileName);

            Change.Model.NewsModel model = new Change.Model.NewsModel();
            model.Title = Title;
            model.NTypes = NTypes;
            model.Content = Content;
            model.PhotoUrl = "UploadFiles/" + newFileName;
            model.PushTime = PushTime;
            model.States = States;

            Change.BLL.NewsBll bll = new Change.BLL.NewsBll();
            
            if (bll.Add(model)>0)
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "News.aspx");
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