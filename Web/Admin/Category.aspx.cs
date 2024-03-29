﻿using Change.BLL;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class Category : System.Web.UI.Page
    {
        public int PageIndex = 1;//当前页
        public int pagecount = 0;//总页数
        public int Total = 0;//总数
        public int PageSize = 5;//页大小
        CategoryBll categoryBll = new CategoryBll();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                PageSize = Convert.ToInt32(this.DropDownList1.SelectedValue);
                GetInfo(PageSize);
            }
        }
        public void GetInfo(int PageSize)
        {
            string Param = Context.Request.Params.Get("page");
            PageIndex = string.IsNullOrEmpty(Param) ? 1 : Convert.ToInt32(Param);

            DataSet ds = new DataSet();
            //页大小

            //分页请求数据
            ds = categoryBll.GetList(PageSize, PageIndex, "ParentId is Null");
            this.CategoryRepeater1.DataSource = ds.Tables[0];
            this.CategoryRepeater1.DataBind();
            //总数赋值
            Total = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
            //总页数
            pagecount = (Total / PageSize) < 1 ? 1 : (Total % PageSize == 0 ? Total / PageSize : (Total / PageSize) + 1);

            //GetList(int PageSize, int PageIndex, string strWhere)
        }
       
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageSize = Convert.ToInt32(this.DropDownList1.SelectedValue);
            GetInfo(PageSize);
        }

        protected void AddCategory_Click(object sender, EventArgs e)
        {
            this.NewCateName.Visible = true;
            this.btnCancle.Visible = true;
            this.btn_addCateName.Visible = true;
        }
        protected void btn_addCateName_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.NewCateName.Text.Trim().Length == 0)
            {
                strErr += "类别名不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            string CateName = this.NewCateName.Text;

            Change.Model.CategoryModel model = new Change.Model.CategoryModel();
            model.CateName = CateName;

            Change.BLL.CategoryBll bll = new Change.BLL.CategoryBll();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "添加成功！", "Category.aspx");
        }
        public void btnCancle_Click(object sender, EventArgs e)
        {
            this.NewCateName.Visible = false;
            this.btnCancle.Visible = false;
            this.btn_addCateName.Visible = false;
        }
        
    }
}