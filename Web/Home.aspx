﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Change.Web.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Change商城</title>
    <style>
        #page_header {
            height: 20px;
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
        <div>测试</div>
        <asp:LinkButton runat="server" OnClick="Unnamed2_Click" ID="btnToReg">注册</asp:LinkButton>
        <asp:LinkButton runat="server" OnClick="Unnamed1_Click" ID="btnToLog">登录</asp:LinkButton>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
