<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/AdminMasterPag.Master" AutoEventWireup="true" CodeBehind="NewsDetails.aspx.cs" Inherits="Change.Web.Admin.NewsDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <li class="on"><a href="News.aspx">促销资讯</a></li>
    <li><a href="Category.aspx">商品类型</a></li>
    <li><a href="Product.aspx">上架商品</a></li>
    <li><a href="Orders.aspx">订单管理</a></li>
    <li><a href="Users.aspx">用户管理</a></li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="add_yfmb_style">
            <ul class="add_template_style">
                <li>
                    <label class="name">标题</label><div class="add_content">
                        <asp:TextBox ReadOnly="True" ID="txtTitle" CssClass="addtext_name" runat="server" Width="300px"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <label class="name">分类</label><div class="add_content">
                        <asp:TextBox ReadOnly="True" ID="txtNTypes" CssClass="addtext_name" runat="server" Width="300px"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <label class="name">发布时间</label>
                    <div class="add_content">
                        <input class="addtext_name" readonly id="txtPushTime" placeholder="yyyy-MM-dd" width="150px" runat="server" />
                    </div>

                </li>
                <li>
                    <label class="name">图片</label>
                    <div class="file-uploader-wrap add_content">
                        <div class="file-uploader-wrap-fake">
                            <asp:TextBox ID="PathDisplayer" ReadOnly="True" class="input-text" runat="server"></asp:TextBox>
                            <a href="javascript:void(0)" class="link-btn">选择文件</a>
                            <asp:FileUpload ID="txtPhotoUrl" runat="server" />
                        </div>
                    </div>
                </li>
                <li>
                    <label class="name">状态</label>
                    <div class="add_content">
                        <p class="radio_style">
                            <label>
                                <asp:RadioButton value="0" ID="txtStates0" runat="server" Checked="True" GroupName="RadioGroup1" />
                                <span>置顶</span></label>
                            <label>
                                <asp:RadioButton value="1" ID="txtStates1" runat="server" GroupName="RadioGroup1" />
                                <span>热点</span></label>
                            <br />
                        </p>
                    </div>
                </li>
                <li>
                    <label class="name">内容</label>
                    <div class="add_content" id="txtContent" runat="server">
                        <p>欢迎使用 <b>wangEditor</b> 富文本编辑器</p>
                    </div>
                </li>
                <li class="center">
                    <a href="News.aspx"  class="quxiao_btn">返&nbsp;&nbsp;&nbsp;&nbsp;回</a>
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

            $("#<%=txtPushTime.ClientID%>").val("<%=initDate%>");

            var E = window.wangEditor
            var editor = new E('#<%=txtContent.ClientID%>')
            // 或者 var editor = new E( document.getElementById('editor') )
            // 配置服务器端地址
            editor.customConfig.uploadImgServer = '../up.aspx';
            // 限制一次最多上传 1 张图片
            editor.customConfig.uploadImgMaxLength = 1

            editor.create()

            $("#<%=txtPhotoUrl.ClientID%>").hide();
            $(".link-btn").hide();
        });
        </script>
</asp:Content>
