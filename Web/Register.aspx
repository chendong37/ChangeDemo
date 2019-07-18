<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Change.Web.Register1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>注册</title>
    <style>
        form {
            color: #575454;
            width: 500px;
            margin: 20px auto;
            font-size: 15px;
        }

        .label {
            color: red;
            font-size: 12px;
            font-family: 'Lucida Console';
        }

        input.Tb {
            border-radius: 5px;
        }

        .user_name {
            width: 240px;
            height: 38px;
            line-height: 38px;
            border: 1px solid #000;
            background: url(login_img_03.png) no-repeat left center;
            padding-left: 30px;
        }

            .user_name input {
                width: 230px;
                height: 36px;
                border: 1px solid #fff;
                color: #666;
            }

        .password {
            width: 240px;
            height: 38px;
            line-height: 38px;
            border: 1px solid #dfe1e8;
            background: url(login_img_09.png) no-repeat left center;
            padding-left: 30px;
        }

            .password input {
                width: 230px;
                height: 36px;
                border: 1px solid #000;
                color: #666;
            }

        .transButton {
            border: solid 1px;
            background-color: transparent;
        }

        #btnRegister {
            font-size: 14px;
        }

        #linkToLogin {
            text-decoration: none;
        }

        #rPwdText {
            text-decoration: none;
        }

        body {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <h2>欢迎注册</h2>

        <h3>每一天，记录美。</h3>

        <br />

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>


        <asp:TextBox runat="server" ID="rUserNameText" Height="40px" Width="490px" CssClass="Tb"></asp:TextBox>

        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:CustomValidator ID="CustomValidator1" runat="server"
                    ControlToValidate="rUserNameText" ErrorMessage="*"
                    OnServerValidate="CustomValidator1_ServerValidate">
                </asp:CustomValidator>
            </ContentTemplate>

        </asp:UpdatePanel>
        <br />
        <asp:TextBox runat="server" ID="rPwdText" TextMode="Password" Height="40px" Width="490px" CssClass="Tb"></asp:TextBox>
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:CustomValidator ID="CustomValidator2" runat="server"
                    ControlToValidate="rPwdText" ErrorMessage="*"
                    OnServerValidate="CustomValidator2_ServerValidate">
                </asp:CustomValidator>
            </ContentTemplate>

        </asp:UpdatePanel>
        <br />
        <asp:TextBox runat="server" ID="rrPwdText" TextMode="Password" Height="40px" Width="490px" CssClass="Tb"></asp:TextBox>
        <br />
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:CustomValidator ID="CustomValidator3" runat="server"
                    ControlToValidate="rrPwdText" ErrorMessage="*"
                    OnServerValidate="CustomValidator3_ServerValidate">
                </asp:CustomValidator>
            </ContentTemplate>

        </asp:UpdatePanel>

        <br />
         <asp:TextBox runat="server" ID="rEmailText" Height="40px" Width="490px" CssClass="Tb"></asp:TextBox>

        <br />
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <asp:CustomValidator ID="CustomValidator4" runat="server"
                    ControlToValidate="rEmailText" ErrorMessage="*"
                    OnServerValidate="CustomValidator4_ServerValidate">
                </asp:CustomValidator>
            </ContentTemplate>

        </asp:UpdatePanel>
        <br />
        <asp:TextBox runat="server" ID="rNickText" Height="40px" Width="490px" CssClass="Tb"></asp:TextBox>

        <br />
        <table>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked="true" />
                </td>
                <td>
                    <span>同意</span>
                    <asp:LinkButton runat="server" Text="服务条款" ID="ckItem"></asp:LinkButton>
                </td>
                <td></td>
                <td>

                    <asp:LinkButton ID="linkToLogin" runat="server" Text="已有账号?登录" OnClick="linkToLogin_Click"></asp:LinkButton>
                </td>
            </tr>
        </table>


        <asp:Button ID="btnRegister" runat="server" CssClass="transButton" Height="49px" Text="注    册" Width="500px" OnClick="btnRegister_Click" />

    </form>
</body>
<script type="text/javascript">
    function watermark(id, value) {
        var obj = document.getElementById(id);
        var isPsdMode = false;
        if (obj.type == "password") {
            obj.type = "text";
            isPsdMode = true;
        }
        obj.value = value;
        obj.style.color = "Gray";
        //获取焦点事件  
        obj.onfocus = function () {

            obj.style.color = "Black";
            if (isPsdMode) {
                obj.type = "password";
            }
            if (this.value == value) {
                this.value = '';
            }
        };
        //失去焦点事件  
        obj.onblur = function () {
            if (this.value == "") {
                if (isPsdMode) {
                    obj.type = "text";
                }
                this.value = value;
                obj.style.color = "Gray";
            }
            else {
                obj.style.color = "Black";
            }
        };
    }
    window.onload = function () {
        var arr = [{ 'id': 'rUserNameText', 'desc': '用户名' }, { 'id': 'rPwdText', 'desc': '密码' }, { 'id': 'rrPwdText', 'desc': '确认密码' }, { 'id': 'rEmailText', 'desc': '邮箱' }, { 'id': 'rNickText', 'desc': '昵称' }];
        for (var i = 0; i < arr.length; i++) {
            watermark(arr[i].id, arr[i].desc);
        }
    };
</script>
</html>
