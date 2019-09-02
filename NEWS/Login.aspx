<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NEWS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>NEWS-登录</title>
    <style type="text/css">
        * {
            font-family: 微软雅黑,Consolas;
        }

        #code {
            font-family: Arial;
            font-style: italic;
            font-weight: bold;
            border: 0;
            letter-spacing: 2px;
            color: blue;
        }

        #txtPwd {
            margin-left: 15px;
        }

        div {
            margin-top: 18px;
        }

        #btnResetPwd {
            margin-left: 20px;
        }

        #btnSignIn, #btnLogin {
            margin-top: 2px;
        }

        .textBox {
            border: 0px;
            border-bottom: 1px solid #b6b6b6;
        }

        #lblTip {
            line-height: 30px;
        }

        #btn_stu, #btn_tea {
            margin: 0 5px;
        }

        td {
            max-width: 200px;
            overflow: auto;
        }
    </style>
    <script type="text/javascript">
        function ClientValidate(sender, args) {
            var url = from1.imgValidCode.src;
            var index = url.lastIndexOf("=");
            var code = url.substring(index + 1);
            if (code == from1.txtValidCode.value) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }
    </script>
    

</head>
<body style="overflow:visible">
    <form id="form1" runat="server">
   <%-- <asp:TextBox id="stopInput" Visible="false" Text="" runat="server" OnTextChanged="startTimer"></asp:TextBox>--%><%-- 禁止输入为true,反之为false--%>
        <div style="width:400px; margin:200px auto 0 auto;left:-115px;">
                <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
            <div>
                <asp:Label ID="Label1" runat="server" Text="我是" class="lbl_u_p"></asp:Label>
                <asp:Button ID="btn_stu" runat="server" Text="学生" OnClick="btn_stu_Click" CausesValidation="false" Width="80px" BackColor="LightGray" BorderWidth="0px" ForeColor="White" Height="25px" Font-Size="Small"/>
                <asp:Button ID="btn_tea" runat="server" Text="教师" OnClick="btn_tea_Click" CausesValidation="false" Width="80px" BackColor="#CCCCCC" BorderWidth="0px" ForeColor="White" Height="25px" Font-Size="Small"/>
                <asp:Button ID="btn_admin" runat="server" Text="管理员" OnClick="btn_admin_Click" CausesValidation="false" Width="80px" BackColor="LightGray" BorderWidth="0px" ForeColor="White" Height="25px" Font-Size="Small"/>
            </div>
            <div>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <label id="lbl_username" class="lbl_u_p" style="color: #808080;">用户名</label>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="textBox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div>
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <label id="lbl_pwd"" class="lbl_u_p"style="color: #808080; ">密码</label>
                        <asp:TextBox ID="txtPwd" runat="server" CssClass="textBox"></asp:TextBox>
                        <asp:Button ID="btnResetPwd" OnClick="btnResetPwd_Click" Text="忘记密码" runat="server" CausesValidation="false" BackColor="White" BorderWidth="0px" ForeColor="Silver" Font-Size="14px" ></asp:Button>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:TextBox ID="txtValidCode" runat="server" Width="50px" CssClass="textBox"></asp:TextBox>
                    <asp:Image ID="imgValidCode" runat="server"/>
                    <asp:Button ID="refresh" runat="server" Text="看不清，换一张" Width="110px" BackColor="White" BorderWidth="0px" ForeColor="Silver" Font-Size="14px"/>
                </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            
            <div>
                <asp:Button ID="btnSignIn" OnClick="btnSignIn_Click" CausesValidation="true" Text="登录" runat="server" Width="213px" BackColor="DodgerBlue" BorderWidth="0px" ForeColor="White" Height="30px" Font-Size="Medium" />
                <br />
                <asp:Button ID="btnLogin" OnClick="btnLogin_Click" Text="注册" runat="server" CausesValidation="false" Width="213px" BackColor="#CCCCCC" BorderWidth="0px" ForeColor="White" Height="30px" Font-Size="Medium" ></asp:Button>
            </div>
            <asp:Label ID="lblTip"  ForeColor="#FF6600" runat="server" Height="30px">用户名一般为学号或编号</asp:Label>
            <div>
                <asp:RequiredFieldValidator ID="rfv_name" runat="server" ErrorMessage="* 请输入用户名 " ControlToValidate="txtUsername" Display="Dynamic" ForeColor="#FF6600"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfv_pwd" runat="server" ErrorMessage="* 请输入密码 " ControlToValidate="txtPwd" Display="Dynamic" ForeColor="#FF6600"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfv_validCode" runat="server" ErrorMessage="* 请输入验证码 " ControlToValidate="txtValidCode" Display="Dynamic" ForeColor="#FF6600"></asp:RequiredFieldValidator>
            </div>
            <div >
                <asp:UpdatePanel runat="server" id="UpdatePanel1" UpdateMode="Conditional">
                    <ContentTemplate>
                            <asp:Timer runat="server" id="Timer1" Interval="1000" OnTick="Timer1_Tick" Enabled="False"></asp:Timer>
                        
                            <asp:Label runat="server" Text="抱歉，您登录失败次数过多，请在" id="Labelt1" Visible="false" ForeColor="#FF6600"></asp:Label>
                            <asp:Label runat="server" Text="10" id="LabelTime" Visible="false"></asp:Label>
                            <asp:Label runat="server" Text="秒后再做尝试..." id="Labelt2" Visible="false" ForeColor="#FF6600"></asp:Label>
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>