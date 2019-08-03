using Change.BLL;
using Maticsoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Change.Web.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.CateIdDropDownList1.DataSource = new CategoryBll().GetList("");
                this.CateIdDropDownList1.DataTextField = "CateName";
                this.CateIdDropDownList1.DataValueField = "CateId";
                this.CateIdDropDownList1.DataBind();
                this.CateIdDropDownList1.SelectedIndex = 0;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtTitle.Text.Trim().Length == 0)
            {
                strErr += "标题不能为空！\\n";
            }
            if (this.txtMarketPrice.Text.Trim().Length == 0)
            {
                strErr += "市场价格不能为空！\\n";
            }
            if (this.txtPrice.Text.Trim().Length == 0)
            {
                strErr += "本地价格不能为空！\\n";
            }
            if (this.txtStock.Text.Trim().Length == 0)
            {
                strErr += "库存数不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }

            string Title = this.txtTitle.Text;
            string CateId = this.CateIdDropDownList1.SelectedValue;
            string MarketPrice = this.txtMarketPrice.Text;
            string Price = this.txtPrice.Text;
            string Content = this.txtContentVal.Text;
            string Stock = this.txtStock.Text;
            //DateTime PostTime = new DateTime();

            Change.Model.ProductModel model = new Change.Model.ProductModel();
            model.Title = Title;
            model.CateId = Convert.ToInt32(CateId);
            model.MarketPrice = Convert.ToDecimal(MarketPrice);
            model.Price = Convert.ToDecimal(Price);
            model.Content = Content;
            model.Stock = Convert.ToInt32(Stock);
            //model.PostTime = PostTime;

            Change.BLL.ProductBll bll = new Change.BLL.ProductBll();

            if (bll.Add(model) > 0)
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "Product.aspx");
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