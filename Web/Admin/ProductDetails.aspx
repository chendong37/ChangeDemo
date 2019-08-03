<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMasterPag.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Change.Web.Admin.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <li><a href="News.aspx">促销资讯</a></li>
    <li><a href="Category.aspx">商品类型</a></li>
    <li class="on"><a href="Product.aspx">上架商品</a></li>
    <li><a href="Orders.aspx">订单管理</a></li>
    <li><a href="Users.aspx">用户管理</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="add_yfmb_style">
            <ul class="add_template_style">
                <li>
                    <label class="name">商品名</label><div class="add_content">
                        <asp:TextBox ReadOnly="true" ID="txtTitle" CssClass="addtext_name" runat="server" Width="300px"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <label class="name">商品分类</label><div class="add_content">
                        <asp:DropDownList ReadOnly="true"  ID="CateIdDropDownList1" runat="server"></asp:DropDownList>
                    </div>
                </li>
                <li>
                    <label class="name">市场价格</label><div class="add_content">
                        <asp:TextBox  ReadOnly="true"  ID="txtMarketPrice" CssClass="addtext_name" runat="server" Width="300px"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <label class="name">本站价格</label><div class="add_content">
                        <asp:TextBox ReadOnly="true"  ID="txtPrice" CssClass="addtext_name" runat="server" Width="300px"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <label class="name">商品库存</label><div class="add_content">
                        <asp:TextBox ReadOnly="true"  ID="txtStock" CssClass="addtext_name" runat="server" Width="300px"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <label class="name">商品描述</label>
                    <div class="add_content" id="txtContent" runat="server">
                        <p>欢迎使用 <b>wangEditor</b> 富文本编辑器</p>
                    </div>
                </li>
                <li class="center">
                    <a href="Product.aspx" class="quxiao_btn">返回</a>
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
                

            var E = window.wangEditor
            var editor = new E('#<%=txtContent.ClientID%>')
            // 或者 var editor = new E( document.getElementById('editor') )
            // 配置服务器端地址
            editor.customConfig.uploadImgServer = '../up.aspx';
            // 限制一次最多上传 1 张图片
            editor.customConfig.uploadImgMaxLength = 1

            editor.create()


                
            $("#<%=txtContent.ClientID%>").hover(function () {
                $("#<%=txtContentVal.ClientID%>").val(editor.txt.html());
                })

            });

        </script>

</asp:Content>