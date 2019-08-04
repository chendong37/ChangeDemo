<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMasterPag.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Change.Web.Admin.Orders" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <li><a href="News.aspx">促销资讯</a></li>
    <li><a href="Category.aspx">商品类型</a></li>
    <li><a href="Product.aspx">上架商品</a></li>
    <li class="on"><a href="Orders.aspx">订单管理</a></li>
    <li><a href="Users.aspx">用户管理</a></li>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView
        AutoGenerateColumns="False" DataKeyNames="OrdersID"
        AllowPaging="True" OnPageIndexChanging="gvOrdersInfo_PageIndexChanging" PageSize="2"
        ID="OrdersGridView1" runat="server" CellPadding="5" EnableModelValidation="True" ForeColor="#333333" GridLines="Horizontal" AllowSorting="True" BorderColor="#CCCCFF" BorderStyle="Solid" BorderWidth="1px" CellSpacing="5" HorizontalAlign="Center" Width="80%">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="Orderdate" HeaderText="下单日期" />
            <asp:BoundField DataField="Total" HeaderText="订单总额" />
            <asp:BoundField DataField="DeliveryDate" HeaderText="收货日期" />
            <asp:TemplateField  HeaderText="订单状态" SortExpression="States">
                <ItemTemplate>
                    <asp:Label id="statesName" runat="server" Text='<%# GetStatusName(Eval("States")) %>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Consignee" HeaderText="收件人姓名" />
            <asp:BoundField DataField="UserName" HeaderText="登录名" />
            <asp:TemplateField  HeaderText="操作" SortExpression="OrderId">
                <ItemTemplate>
                    <a href="OrdersDetail.aspx?OrderId=<%# Eval("OrdersID") %>">详情</a>
                    <asp:Button ID="setStatesName" runat="server" OnClick="statesName_Click" CommandName="setStatus" CommandArgument='<%# Eval("OrdersID") +","+ Eval("States") %>' Text='<%# GetOperName(Eval("States")) %>'></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
           <%-- <asp:TemplateField HeaderText="设备状态" SortExpression="DeviceState">

                <EditItemTemplate>
                    <asp:TextBox ID="txtDeviceState" runat="server" Text='<%#Server.HtmlDecode(Eval("States").ToString()) == "0" ? "入库" : "出库"%>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDeviceState" runat="server" Text='<%#Eval("States").ToString() == "0" ? "入库" : Eval("States").ToString()=="1"?"出库":""%>'>       </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>

    </asp:GridView>
    <%-- <asp:ListView ID="OrdersListView1" runat="server" OnItemUpdating="OrdersListView1_ItemUpdating"  ItemContainerID= "ItemPlaceHolder">
        <LayoutTemplate>
            <div class="Order_form_list">
                <table border="1" bordercolor="#00ff00" width="500" border-collapse="collapse;">
                    <thead>
                        <tr>
                            <td class="list_name_title0">下单日期</td>
                            <td class="list_name_title1">订单总额(元)</td>
                            <td class="list_name_title2">收货日期</td>
                            <td class="list_name_title3">订单状态</td>
                            <td class="list_name_title4">收件人姓名</td>
                            <td class="list_name_title5">登录名</td>
                            <td class="list_name_title6">操作</td>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="ItemPlaceHolder"></asp:PlaceHolder>
                    </tbody>
                </table>
            </div>
            <asp:DataPager runat="server" ID="ContactsDataPager" PageSize="2">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true"
                        FirstPageText="首页" LastPageText="尾页"
                        NextPageText="下一页" PreviousPageText="上一页" />
                </Fields>
            </asp:DataPager>

        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><%#Eval("Orderdate")%></td>
                <td><%#Eval("Total")%></td>
                <td><%#Eval("DeliveryDate")%></td>
                <td><%#Eval("States")%></td>
                <td><%#Eval("DeliveryID")%></td>
                <td><%#Eval("UserId")%></td>
                <td>
                    <a href="OrdersDetail.aspx?OrdersID=<%#Eval("OrdersID")%>">详情</a>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" />
                </td>
            </tr>
        </itemtemplate>
    </asp:ListView>--%>
</asp:Content>
