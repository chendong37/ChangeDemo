<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMasterPag.Master" AutoEventWireup="true" CodeBehind="ProductPhoto.aspx.cs" Inherits="Change.Web.Admin.ProductPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <li><a href="News.aspx">促销资讯</a></li>
    <li><a href="Category.aspx">商品类型</a></li>
    <li class="on"><a href="Product.aspx">上架商品</a></li>
    <li><a href="Orders.aspx">订单管理</a></li>
    <li><a href="Users.aspx">用户管理</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Inside_pages clearfix">

        <div class="right_style">
            <!--内容详细-->
            <div class="title_style"><em></em><a href="Product.aspx">商品类型</a>>图片管理></div>
            <div class="content_style">
                <div class="Release_product_style">
                        <table cellpadding="0" cellspacing="0" style="margin: 0 auto">
                            <tbody>
                                <tr>
                                    <td>
                                        <table class="Publicize_img_style">
                                            <tbody>
                                                <tr>
                                                    <td colspan="2">
                                                        <%= Session["Title"] %>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td colspan="2">
                                                        <%--<input type="submit" value="添加" class="Add_btn">--%>
                                                        <asp:FileUpload ID="txtPhotoUrl" runat="server"/>
                                                        <asp:Button ID="btn_add" OnClick="btn_add_Click" runat="server" Text="上传" />
                                                    </td>
                                                </tr>
                                                <tr class="label">
                                                    <td>预览图</td>
                                                    <td>操作</td>
                                                </tr>
                                                <asp:Repeater ID="Repeater1" runat="server">
                                                    <ItemTemplate>
                                                        <tr style="    text-align: center;">
                                                            <td>
                                                                <img width="100" height="100" src="../<%# Eval("PhotoUrl") %>"" alt="商品图" />
                                                            </td>
                                                            <td>
                                                                <a href= "?PhotoId=<%# Eval("PhotoId") %>"  class="delete_btn">删除</a>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>

                                            </tbody>
                                        </table>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                        <%--<a href="#" class="Next_btn">提交</a>--%>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
