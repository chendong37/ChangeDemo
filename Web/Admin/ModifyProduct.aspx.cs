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
    public partial class ModifyProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ProductModel productModel = new ProductModel();
                ProductBll productBll = new ProductBll();
                int ProductId = Convert.ToInt32(Context.Request.Params.Get("ProductId"));
                productModel = productBll.GetModel(ProductId);

                Session["productModel"] = productModel;

                
                this.CateIdDropDownList1.SelectedValue = productModel.CateId.ToString();

                this.txtTitle.Text= productModel.Title;
                this.txtMarketPrice.Text= productModel.MarketPrice.ToString();
                this.txtPrice.Text= productModel.Price.ToString();
                this.txtContent.InnerHtml = productModel.Content;
                this.txtStock.Text = productModel.Stock.ToString();
                this.CateIdDropDownList1.DataSource = new CategoryBll().GetAllList();
                this.CateIdDropDownList1.DataTextField = "CateName";
                this.CateIdDropDownList1.DataValueField = "CateId";
                this.CateIdDropDownList1.DataBind();
                
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
            
            ProductModel model = (ProductModel)Session["productModel"];
            model.Title = Title;
            model.CateId = Convert.ToInt32(CateId);
            model.MarketPrice = Convert.ToDecimal(MarketPrice);
            model.Price = Convert.ToDecimal(Price);
            model.Content = Content;
            model.Stock = Convert.ToInt32(Stock);
            //model.PostTime = PostTime;

            Change.BLL.ProductBll bll = new Change.BLL.ProductBll();
            
            if (bll.Update(model))
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "修改成功！", "Product.aspx");
            }
        }
    }
}