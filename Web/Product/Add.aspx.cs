﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Change.Web.Product
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtTitle.Text.Trim().Length==0)
			{
				strErr+="商品名不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCateId.Text))
			{
				strErr+="分类编号(外键)格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtMarketPrice.Text))
			{
				strErr+="标记价格（市场价格）格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtPrice.Text))
			{
				strErr+="本地价格（本站价格）格式错误！\\n";	
			}
			if(this.txtContent.Text.Trim().Length==0)
			{
				strErr+="商品说明描述不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtPostTime.Text))
			{
				strErr+="上架时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtStock.Text))
			{
				strErr+="库存数量格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Title=this.txtTitle.Text;
			int CateId=int.Parse(this.txtCateId.Text);
			decimal MarketPrice=decimal.Parse(this.txtMarketPrice.Text);
			decimal Price=decimal.Parse(this.txtPrice.Text);
			string Content=this.txtContent.Text;
			DateTime PostTime=DateTime.Parse(this.txtPostTime.Text);
			int Stock=int.Parse(this.txtStock.Text);

			Change.Model.Product model=new Change.Model.Product();
			model.Title=Title;
			model.CateId=CateId;
			model.MarketPrice=MarketPrice;
			model.Price=Price;
			model.Content=Content;
			model.PostTime=PostTime;
			model.Stock=Stock;

			Change.BLL.Product bll=new Change.BLL.Product();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}