<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMasterPag.Master" AutoEventWireup="true" CodeBehind="ModifyUsers.aspx.cs" Inherits="Change.Web.Admin.ModifyUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <li><a href="News.aspx">促销资讯</a></li>
    <li><a href="Category.aspx">商品类型</a></li>
    <li><a href="Product.aspx">上架商品</a></li>
    <li><a href="Orders.aspx">订单管理</a></li>
    <li class="on"><a href="Users.aspx">用户管理</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="add_yfmb_style">
            <ul class="add_template_style">
                <li>
                    <label class="name">登录名</label><div class="add_content">
                        <asp:TextBox ID="txtUserName" CssClass="addtext_name" runat="server" Width="300px"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <label class="name">密码</label><div class="add_content">
                        <asp:TextBox ID="txtPwd" CssClass="addtext_name" runat="server" Width="300px"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <label class="name">邮箱</label><div class="add_content">
                        <asp:TextBox ID="txtEmail" CssClass="addtext_name" runat="server" Width="300px"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <label class="name">昵称</label><div class="add_content">
                        <asp:TextBox ID="txtNick" CssClass="addtext_name" runat="server" Width="300px"></asp:TextBox>
                    </div>
                </li>
               
                <li class="center">
                    <asp:Button ID="btnSave" CssClass="bc_btn" runat="server" Text="保存并返回" OnClick="btnSave_Click"></asp:Button>
                    
                    <a href="Users.aspx" class="quxiao_btn">取消</a>
                </li>
                <li style="display: none">
                    <asp:TextBox ID="txtContentVal" runat="server" TextMode="MultiLine"></asp:TextBox>
                </li>
            </ul>
        </div>
        <script>
            $(document).ready(function () {
                $('.add_template_style input').iCheck({
                    checkboxClass: 'icheckbox_flat-green',
                    radioClass: 'iradio_flat-green'
                });
            });
        </script>
</asp:Content>
