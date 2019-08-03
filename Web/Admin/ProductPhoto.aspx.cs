using Change.BLL;
using Change.Model;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class ProductPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                PhotoBll bll = new PhotoBll();
                PhotoModel model = new PhotoModel();
                if (Request.QueryString["PhotoId"] != null)
                {
                    int photoId = Convert.ToInt32(Request.QueryString["PhotoId"]);
                    if (bll.Delete(photoId))
                    {
                        MessageBox.Show(this, "删除成功！");
                        Response.Redirect(Request.UrlReferrer.ToString());
                    }
                }
                //ViewState["BackUrl"] = Request.UrlReferrer.ToString();
                int ProductId = Convert.ToInt32(Context.Request.Params.Get("ProductId"));
                Session["Title"] = Request.QueryString["Title"];
                DataSet ds = bll.GetList("ProductId=" + ProductId);
                this.Repeater1.DataSource = ds;
                this.Repeater1.DataBind();
                Session["ProductId"] = ProductId;
            }
            
        }
        
        protected void btn_add_Click(object sender, EventArgs e)
        {
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
            PhotoModel model = new PhotoModel();
            PhotoBll bll = new PhotoBll();
            model.ProductId = (int)Session["ProductId"];
            model.PhotoUrl = "UploadFiles/" + newFileName;
            if (bll.Add(model)>0)
            {
                Response.Redirect(Request.Url.ToString());
            }
            
        }
    }
}