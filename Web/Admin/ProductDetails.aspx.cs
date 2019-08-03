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
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ProductModel productModel = new ProductModel();
                ProductBll productBll = new ProductBll();
                int ProductId = Convert.ToInt32(Context.Request.Params.Get("ProductId"));
                productModel = productBll.GetModel(ProductId);

                this.CateIdDropDownList1.SelectedValue = productModel.CateId.ToString();

                this.txtTitle.Text = productModel.Title;
                this.txtMarketPrice.Text = productModel.MarketPrice.ToString();
                this.txtPrice.Text = productModel.Price.ToString();
                this.txtContent.InnerHtml = productModel.Content;
                this.txtStock.Text = productModel.Stock.ToString();
                this.CateIdDropDownList1.DataSource = new CategoryBll().GetAllList();
                this.CateIdDropDownList1.DataTextField = "CateName";
                this.CateIdDropDownList1.DataValueField = "CateId";
                this.CateIdDropDownList1.DataBind();

            }
        }
    }
}