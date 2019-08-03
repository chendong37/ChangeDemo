<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMasterPag.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Change.Web.Admin.Users" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <li><a href="News.aspx">促销资讯</a></li>
    <li><a href="Category.aspx">商品类型</a></li>
    <li><a href="Product.aspx">上架商品</a></li>
    <li><a href="Orders.aspx">订单管理</a></li>
    <li class="on"><a href="Users.aspx">用户管理</a></li>
</asp:Content>   
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Inside_pages clearfix">

        <!--内容-->
        <div class="right_style">
            <!--内容详细-->
            <div class="title_style"><em></em>用户列表</div>
            <div class="content_style">
                <div class="Products_area_style">
                    <div class="Add_product_style"><a href="AddUsers.aspx" class="Add_btn">添加用户</a> </div>

                    <div class="Products_list_style">
                        <table>
                            <thead>
                                <tr class="title">
                                    <td class="title_name">登录名</td>
                                    <td class="inventory">密码</td>
                                    <td class="news_time">邮箱</td>
                                    <td class="status">昵称</td>
                                    <%--<td class="status">默认地址</td>--%>
                                    <td class="operating">操作</td>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="ProductRepeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><a href="javascript:(0)"><%# Eval("UserName") %></a></td>
                                            <td><%# Eval("Pwd") %></td>
                                            <td><%# Eval("Email") %></td>
                                            <td><%#  Eval("Nick") %></td>
                                            <%--<td><%#  Eval("CateId") %></td>--%>
                                            <td class="operating_btn relative">
                                                <a href="ModifyUsers.aspx?UserId=<%#  Eval("UserId") %>" class="fzxx_btn">编辑</a>
                                                <a href="UsersDetails.aspx?UserId=<%#  Eval("UserId") %>" class="pjgl_btn">详情</a>
                                                <a href="DeleteUsers.aspx?UserId=<%#  Eval("UserId") %>" class="szkc_btn" >删除</a>
                                              
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
                            <a href="Product.aspx">首页</a>
                            <a href="Product.aspx?page=<%=(PageIndex==1)?1:PageIndex-1 %>">上一页</a>
                            <a href="Product.aspx?page=<%=(PageIndex==pagecount)?pagecount:PageIndex+1 %>">下一页</a>
                            <a href="Product.aspx?page=<%=pagecount%>">尾页</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
