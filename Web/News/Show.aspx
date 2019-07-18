<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Change.Web.News.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		资讯编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNewsID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		标题
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTitle" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		分类
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblNTypes" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		内容
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblContent" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		图片地址
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPhotoUrl" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		发布时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblPushTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		消息状态：0置顶
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblStates" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




