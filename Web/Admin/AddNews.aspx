<%@ Page Language="C#" MasterPageFile="~/Masters/AdminMasterPag.Master" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="Change.Web.Admin.AddNews" ValidateRequest="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <li class="on"><a href="News.aspx">促销资讯</a></li>
    <li><a href="Category.aspx">商品类型</a></li>
    <li><a href="Product.aspx">上架商品</a></li>
    <li><a href="Orders.aspx">订单管理</a></li>
    <li><a href="Users.aspx">用户管理</a></li>
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="add_yfmb_style">
            <ul class="add_template_style">
                <li>
                    <label class="name">标题</label><div class="add_content">
                        <asp:TextBox ID="txtTitle" CssClass="addtext_name" runat="server" Width="300px"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <label class="name">分类</label><div class="add_content">
                        <asp:TextBox ID="txtNTypes" CssClass="addtext_name" runat="server" Width="300px"></asp:TextBox>
                    </div>
                </li>
                <li>
                    <label class="name">发布时间</label>
                    <div class="add_content">
                        <input class="addtext_name" readonly="" id="txtPushTime" placeholder="yyyy-MM-dd" width="150px" runat="server" />
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
                    <asp:Button ID="btnSave" CssClass="bc_btn" runat="server" Text="保存并返回" OnClick="btnSave_Click"></asp:Button>
                    
                    <a href="News.aspx" class="quxiao_btn">取消新增</a>
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

                var txtPushTime = {
                    elem: '#<%=txtPushTime.ClientID%>',
                format: 'YYYY/MM/DD hh:mm:ss',
                min: laydate.now(),
                max: '2099-06-16 23:59:59',
                istime: true,
                istoday: false
            };
            laydate(txtPushTime);

            var E = window.wangEditor
            var editor = new E('#<%=txtContent.ClientID%>')
            // 或者 var editor = new E( document.getElementById('editor') )
            // 配置服务器端地址
            editor.customConfig.uploadImgServer = '../up.aspx';
            // 限制一次最多上传 1 张图片
            editor.customConfig.uploadImgMaxLength = 1

            editor.create()



            $("#<%=txtPhotoUrl.ClientID%>").hide();
            $(".link-btn,#<%=PathDisplayer.ClientID%>").click(function () {
                $("#<%=txtPhotoUrl.ClientID%>").trigger("click");
            });
            $("#<%=txtPhotoUrl.ClientID%>").change(function () {
                var file = $("#<%=txtPhotoUrl.ClientID%>").val();
                var fileName = getFileName(file);
                function getFileName(o) {
                    var pos = o.lastIndexOf("\\");
                    return o.substring(pos + 1);
                }
                $("#<%=PathDisplayer.ClientID%>").val(fileName);
            });

            $("#<%=txtContent.ClientID%>").hover(function () {
                $("#<%=txtContentVal.ClientID%>").val(editor.txt.html());
                })

            });

        </script>

</asp:Content>
