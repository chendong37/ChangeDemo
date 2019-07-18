<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Change.Web.Orders.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		订单编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOrdersID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		下单时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblOrderdate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户编号(外键)
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblUserId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		订单总价
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTotal" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		用户收货地址编号(外键)
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDeliveryID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		收货日期
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblDeliveryDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		订单状态：
0未付款
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStates" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		备注
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblRemark" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




