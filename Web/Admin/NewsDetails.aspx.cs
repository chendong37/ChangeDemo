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
    public partial class NewsDetails : System.Web.UI.Page
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

            }
        }
    }
}