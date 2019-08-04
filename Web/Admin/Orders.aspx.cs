using Change.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindListView();
            }
        }
        private void BindListView()
        {
            this.OrdersGridView1.DataSource = new OrdersBll().GetAllList();
            this.OrdersGridView1.DataBind();
        }

        protected void gvOrdersInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.OrdersGridView1.PageIndex = e.NewPageIndex;
            BindListView();
        }
        public string GetStatusName(object id)
        {
            string str = "";
            switch ((int)id)
            {
                case 0: str = "未付款"; break;
                case 1: str = "已付款"; break;
                case 2: str = "已发货"; break;
                case 3: str = "已收货"; break;
                case 4: str = "已评价"; break;
                default:
                    break;
            }
            return str;
        }
        public string GetOperName(object id)
        {
            string str = "";
            switch ((int)id)
            {
                case 0: str = "关闭订单"; break;
                case 1: str = "发货"; break;
                default:
                    break;
            }
            return str;
        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            foreach (GridViewRow row in OrdersGridView1.Rows)
            {
                ////在当前命名容器中搜索带指定id参数的服务器控件。
                //Button btnCancel = row.Cells[6].FindControl("btnCancel") as Button;
                ////获取WhetherEat的值
                //string WhetherEat = row.Cells[5].Text.Trim();
                //if (WhetherEat == "未取餐")//如果值为”未取餐“，就显示按钮
                //{
                //    btnCancel.Visible = true;
                //}
                //else
                //{
                //    btnCancel.Visible = false;
                //}
            }
        }

        protected void statesName_Click(object sender, EventArgs e)
        {
            //string[] mes = e.CommandArgument.ToString().Split(',');

            //int id = Convert.ToInt32(mes[0]);
            //int States = Convert.ToInt32(mes[1]);
        }
    }
}