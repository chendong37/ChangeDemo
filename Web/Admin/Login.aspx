<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Change.Web.Admin.Login" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8" />
    <title>登陆</title>
    <link href="../Content/css/base.css" rel="stylesheet" type="text/css" />
    <link href="../Content/css/css.css" rel="stylesheet" type="text/css" />
    <script src="../Content/js/jquery-2.1.1.min.js"></script>
    <style>
        .tab {
            overflow: hidden;
            margin-top: 20px;
            margin-bottom: -1px;
        }

            .tab li {
                display: block;
                float: left;
                width: 100px;
                padding: 10px 20px;
                cursor: pointer;
                border: 1px solid #ccc;
            }

                .tab li.on {
                    background: #90B831;
                    color: #FFF;
                    padding: 10px 20px;
                }

        .conlist {
            padding: 30px;
            border: 1px solid #ccc;
            width: 300px;
        }

        .conbox {
            display: none;
        }
    </style>
    <script>
        $(function () {
            $(".tab li").each(function (i) {
                $(this).click(function () {
                    $(this).addClass("on").siblings().removeClass("on");
                    $(".conlist .conbox").eq(i).show().siblings().hide();
                })
            })
        })
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="login-top">
            <div class="wrapper">
                <div class="fl font30">Change</div>
                <div class="fr">您好，欢迎为生活充电在线！</div>
            </div>
        </div>
        <div class="l_main">
            <div class="l_bttitle2" style="visibility: hidden">
                <!-- <h2>登录</h2>-->
                <h2><a href="#">< 返回首页</a></h2>
            </div>
            <div class="loginbox fl">
                <div class="tab">
                    <ul>
                        <li class="on">管理员</li>
                        <li style="visibility: hidden">我是卖家</li>
                    </ul>
                </div>
                <div class="conlist">
                    <div class="conbox" style="display: block;">
                        <p class="txt-lt">
                            <asp:TextBox ID="loginusername" runat="server" class="loginusername" placeholder="用户名"></asp:TextBox>
                            <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="loginusername"
                                ErrorMessage="*用户名不能为空"  ForeColor="Red"></asp:RequiredFieldValidator>
                        </p>
                        <p class="txt-lt">
                            <asp:TextBox ID="loginuserpassword" runat="server" class="loginuserpassword" placeholder="密码" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator 
                                ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="loginuserpassword"
                                ErrorMessage="*密码不能为空"  ForeColor="Red"></asp:RequiredFieldValidator>
                        </p>
                        <p style="visibility: hidden"><span class="fl fntz14 margin-t10"><a href="#" style="color: #ff6000">立即注册</a></span><span class="fr fntz12 margin-t10"><a href="#">忘记密码？</a></span></p>
                        <p class="txt-lt">
                            <asp:CustomValidator ID="UserCustomValidator" runat="server"></asp:CustomValidator>
                            <asp:Button ID="loginbtn" runat="server" class="loginbtn" Text="登  录" OnClick="loginbtn_Click"></asp:Button>
                        </p>
                    </div>
                    <div class="conbox">
                        <p>
                            <input type="text" class="loginusername">
                        </p>
                        <p>
                            <input type="password" class="loginuserpassword">
                        </p>
                        <p><span class="fl fntz14 margin-t10"><a href="#" style="color: #ff6000">立即注册</a></span><span class="fr fntz12 margin-t10"><a href="#">忘记密码？</a></span></p>
                        <p>
                            <input type="button" class="loginbtn" value="登  录">
                        </p>
                    </div>
                </div>
            </div>

            <div class="fr margin-r100 margin-t45">
                <img src="../Content/images/login-pic.jpg" width="507" height="325"></div>
        </div>
    </form>
</body>
</html>
