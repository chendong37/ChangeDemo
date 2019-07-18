<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Change.Web.Product.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		商品编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblProductId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		商品名
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTitle" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		分类编号(外键)
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCateId" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		标记价格（市场价格）
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblMarketPrice" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		本地价格（本站价格）
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPrice" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		商品说明描述
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContent" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		上架时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPostTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		库存数量
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStock" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




