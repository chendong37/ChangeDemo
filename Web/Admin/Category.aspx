<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMasterPag.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Change.Web.Admin.Category" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <li><a href="News.aspx">促销资讯</a></li>
    <li class="on"><a href="Category.aspx">商品类型</a></li>
    <li><a href="Product.aspx">上架商品</a></li>
    <li><a href="Orders.aspx">订单管理</a></li>
    <li><a href="Users.aspx">用户管理</a></li>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Inside_pages clearfix">

        <!--内容-->
        <div class="right_style">
            <!--内容详细-->
            <div class="title_style"><em></em>商品类型</div>
            <div class="content_style">
                <div class="Products_area_style">
                    <div class="Add_product_style">
                        <asp:Button ID="AddCategory" BorderStyle="None" OnClick="AddCategory_Click" CssClass="Add_btn" runat="server" Text="新建一级分类" />
                        <asp:TextBox ID="NewCateName" CssClass="addtext_catename" runat="server" Visible="false"></asp:TextBox>
                        <asp:Button ID="btnCancle"  BorderStyle="None" OnClick="btnCancle_Click" Visible="false" CssClass="Add_btn" runat="server" Text="取消" />
                        <asp:Button ID="btn_addCateName"  BorderStyle="None" OnClick="btn_addCateName_Click" Visible="false" CssClass="Add_btn" runat="server" Text="提交" />

                    </div>

                    <div class="Products_list_style">
                        <table>
                            <thead>
                                <tr class="title">
                                    <td class="title_name">类型名</td>
                                    <td class="inventory">属性</td>
                                    <td class="operating">操作</td>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="CategoryRepeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><a href="javascript:(0)"><%# Eval("CateName") %></a></td>
                                            <td><a href="CategoryChild.aspx?CateId=<%#  Eval("CateId") %>&CateName=<%# Eval("CateName") %>" class="pjgl_btn">
                                                <img src="../Content/images/m_i_1.png" alt="子类别" /></a></td>
                                            <td class="operating_btn relative">
                                                <%--<a href="AddCategory.aspx?CateId=<%#  Eval("CateId") %>" class="pjgl_btn">新建子类</a>--%>
                                                <a href="ModifyCategory.aspx?CateId=<%#  Eval("CateId") %>&CateName=<%# Eval("CateName") %>" class="fzxx_btn">编辑</a>
                                                <a href="DeleteCategory.aspx?CateId=<%#  Eval("CateId") %>" class="szkc_btn">删除</a>
                                                

                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                               
                            </tbody>
                        </table>
                        <div class="page_style">
                            每页显示 
                            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Selected="True">5</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>50</asp:ListItem>
                            </asp:DropDownList>
                            共<%=pagecount%>页 
                            共<%=Total%>条，
                            当前第<%=PageIndex%>页
                            <a href="Category.aspx">首页</a>
                            <a href="Category.aspx?page=<%=(PageIndex==1)?1:PageIndex-1 %>">上一页</a>
                            <a href="Category.aspx?page=<%=(PageIndex==pagecount)?pagecount:PageIndex+1 %>">下一页</a>
                            <a href="Category.aspx?page=<%=pagecount%>">尾页</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
