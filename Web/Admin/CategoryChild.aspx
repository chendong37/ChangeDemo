<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMasterPag.Master" AutoEventWireup="true" CodeBehind="CategoryChild.aspx.cs" Inherits="Change.Web.Admin.CategoryChild" %>
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
            <div class="title_style"><em></em><a href="Category.aspx">商品类型</a>><%= Session["ParentName"] %>></div>
            <div class="content_style">
                <div class="Products_area_style">
                    <div class="Add_product_style">
                        <asp:Button ID="AddCategory" BorderStyle="None" OnClick="AddCategory_Click" CssClass="Add_btn" runat="server" Text="新建子分类" />
                        <asp:TextBox ID="NewCateName" CssClass="addtext_catename" runat="server" Visible="false"></asp:TextBox>
                        <asp:Button ID="btnCancle"  BorderStyle="None" OnClick="btnCancle_Click" Visible="false" CssClass="Add_btn" runat="server" Text="取消" />
                        <asp:Button ID="btn_addCateName"  BorderStyle="None" OnClick="btn_addCateName_Click" Visible="false" CssClass="Add_btn" runat="server" Text="提交" />

                    </div>

                    <div class="Products_list_style">
                        <table>
                            <thead>
                                <tr class="title">
                                    <td class="title_name">类型名</td>
                                    <td class="operating">操作</td>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="CategoryRepeater1" runat="server">
                                    <ItemTemplate>
                                            <td><a href="javascript:(0)"><%# Eval("CateName") %></a></td>
                                            <td class="operating_btn relative">
                                                <a href="ModifyCategory.aspx?&ParentId=<%=Session["ParentId"] %>&CateId=<%#  Eval("CateId") %>&CateName=<%# Eval("CateName") %>" class="fzxx_btn">编辑</a>
                                                <a href="DeleteCategory.aspx?CateId=<%#  Eval("CateId") %>" class="szkc_btn">删除</a>
                                            </td>
                                        </tr>
                                        </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        
                    </div>
                </div>
            </div>
        </div>
         
    </div>
    
</asp:Content>
