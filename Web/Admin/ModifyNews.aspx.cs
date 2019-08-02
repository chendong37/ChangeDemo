using Change.BLL;
using Change.Model;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class ModifyNews : System.Web.UI.Page
    {

        NewsModel newsModel = new NewsModel();
        NewsBll newsBll = new NewsBll();

        public string initDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                int newsId = Convert.ToInt32(Context.Request.Params.Get("newsId"));
                newsModel = newsBll.GetModel(newsId);
                this.txtTitle.Text = newsModel.Title;
                this.txtNTypes.Text = newsModel.NTypes;
                this.txtContent.InnerHtml = newsModel.Content;
                this.PathDisplayer.Text = newsModel.PhotoUrl;
                initDate = newsModel.PushTime.ToString();
                this.txtStates1.Checked = newsModel.States == 1 ? true : false;
                Session["newsModel"] = newsModel;

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            NewsModel newsModel =(NewsModel)Session["newsModel"];
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
            if (this.txtPhotoUrl.HasFile == true)
            {
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
                newsModel.PhotoUrl = "UploadFiles/" + newFileName;
            }
            
            newsModel.Title = Title;
            newsModel.NTypes = NTypes;
            newsModel.Content = Content;
            newsModel.PushTime = PushTime;
            newsModel.States = States;
            
            if (newsBll.Update(newsModel))
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "修改成功！", "News.aspx");
                //MessageBox.Show(this, "修改成功！");
                //Response.Redirect("News.aspx");
            }
        }
    }
}