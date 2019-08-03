using Change.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        public int PageIndex = 1;//当前页
        public int pagecount = 0;//总页数
        public int Total = 0;//总数
        public int PageSize = 5;//页大小
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PageSize = Convert.ToInt32(this.DropDownList1.SelectedValue);
                GetInfo(PageSize);
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageSize = Convert.ToInt32(this.DropDownList1.SelectedValue);
            GetInfo(PageSize);
        }
        public void GetInfo(int PageSize)
        {
            string Param = Context.Request.Params.Get("page");
            PageIndex = string.IsNullOrEmpty(Param) ? 1 : Convert.ToInt32(Param);

            DataSet ds = new DataSet();
            //页大小

            //分页请求数据
            ds = new UsersBll().GetList(PageSize, PageIndex, null);
            this.ProductRepeater1.DataSource = ds.Tables[0];
            this.ProductRepeater1.DataBind();
            //总数赋值
            Total = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
            //总页数
            pagecount = (Total / PageSize) < 1 ? 1 : (Total % PageSize == 0 ? Total / PageSize : (Total / PageSize) + 1);

            //GetList(int PageSize, int PageIndex, string strWhere)
        }
    }
}