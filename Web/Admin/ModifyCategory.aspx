<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMasterPag.Master" AutoEventWireup="true" CodeBehind="ModifyCategory.aspx.cs" Inherits="Change.Web.Admin.ModifyCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <li><a href="News.aspx">促销资讯</a></li>
    <li class="on"><a href="Category.aspx">商品类型</a></li>
    <li><a href="Product.aspx">上架商品</a></li>
    <li><a href="Orders.aspx">订单管理</a></li>
    <li><a href="Users.aspx">用户管理</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Inside_pages clearfix">

        <!--内容-->
        <div class="right_style">
            <!--内容详细-->
            <div class="title_style"><em></em><a href="Category.aspx">商品类型</a></div>
        </div>
         
    </div>
    <asp:Panel ID="CatePanel1" runat="server">
        <div class="panel panel-warning addDiv">
	  <div class="panel-heading">编辑分类</div>
	  <div class="panel-body">
	    		<table class="addTable">
	    			<tbody>
                        <tr>
	    				    <td>分类名称</td>
	    				    <td>
                                <asp:TextBox ID="CateName" CssClass="form-control" runat="server"></asp:TextBox>
                            </td>
	    			    </tr>
	    			<tr>
                        <td></td>
	    				<td>
	    					<asp:DropDownList ID="ParentId" Visible="false" runat="server"></asp:DropDownList>
	    				</td>
	    			</tr>
	    			<tr class="submitTR">
	    				<td colspan="2" align="center">
                            <asp:Button ID="btn_Update" OnClick="btn_Update_Click" CssClass="btn btn-success" runat="server" Text="提 交" />
	    				    <asp:Button ID="btn_Cancel" OnClick="btn_Cancel_Click" CssClass="btn btn-success" runat="server" Text="取 消" />
                        </td>
	    			</tr>
	    		</tbody></table>
	  </div>
	</div>
    </asp:Panel>
</asp:Content>
