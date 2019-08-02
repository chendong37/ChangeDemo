<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMasterPag.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Change.Web.Admin.News" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <li class="on"><a href="News.aspx">促销资讯</a></li>
    <li><a href="Category.aspx">商品类型</a></li>
    <li><a href="Product.aspx">上架商品</a></li>
    <li><a href="Orders.aspx">订单管理</a></li>
    <li><a href="Users.aspx">用户管理</a></li>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Inside_pages clearfix">

        <!--内容-->
        <div class="right_style">
            <!--内容详细-->
            <div class="title_style"><em></em>促销资讯</div>
            <div class="content_style">
                <div class="Products_area_style">
                    <div class="Add_product_style"><a href="AddNews.aspx" class="Add_btn">发布资讯</a> </div>

                    <div class="Products_list_style">
                        <table>
                            <thead>
                                <tr class="title">
                                    <td class="news_img">图片</td>
                                    <td class="title_name">标题</td>
                                    <td class="inventory">分类</td>
                                    <td class="news_time">发布时间</td>
                                    <td class="status">状态</td>
                                    <td class="operating">操作</td>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="NewsRepeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td >
                                                <img width="100"  height="50" src="../<%# Eval("PhotoUrl") %>" alt="活动图片" />
                                            </td>
                                            <td><a href="javascript:(0)"><%# Eval("Title") %></a></td>
                                            <td><%# Eval("NTypes") %></td>
                                            <td><%# Eval("PushTime") %></td>
                                            <td>
                                                <%# ((int)Eval("States")==0)?"置顶":"热点" %>
                                            </td>
                                            <td class="operating_btn relative">
                                                <a href="ModifyNews.aspx?newsId=<%#  Eval("NewsID") %>" class="fzxx_btn">编辑</a>
                                                <a href="NewsDetails.aspx?newsId=<%#  Eval("NewsID") %>" class="pjgl_btn">详情</a>
                                                <a href="DeleteNews.aspx?newsId=<%#  Eval("NewsID") %>" class="szkc_btn" >删除</a>
                                                
                                                <a href="?updateId=<%#  Eval("NewsID") %>&states=<%#  Eval("States") %>" class="sj_btn"  >
                                                    <%# ((int)Eval("States")==0)?"取消置顶":"置顶" %>
                                                </a>
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
                            <a href="News.aspx">首页</a>
                            <a href="News.aspx?page=<%=(PageIndex==1)?1:PageIndex-1 %>">上一页</a>
                            <a href="News.aspx?page=<%=(PageIndex==pagecount)?pagecount:PageIndex+1 %>">下一页</a>
                            <a href="News.aspx?page=<%=pagecount%>">尾页</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

