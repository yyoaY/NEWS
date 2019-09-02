<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPwdPage.aspx.cs" Inherits="LoginWeb.ResetPwdPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>NEWS-修改密码</title>
    <style type="text/css">
        * {
            font-family: 微软雅黑,Consolas;
        }

        .top {
            height: 30px;
            text-align: center;
            padding: 30px;
            font-size: larger;
        }

        .div_btn {
            margin: 20px auto 0px;
            text-align: center;
        }

        .lbl {
            color: #808080;
        }

        .pa {
            margin-top: 20px;
            line-height: 30px;
        }

        .tip {
            display: block;
            text-align: center;
            margin: 20px auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top">
            修改密码
        </div>
        <div>
            <asp:Panel ID="p_identity" runat="server" HorizontalAlign="Center" CssClass="pa">
                <asp:Label ID="Label4" runat="server" Text="请选择您的身份" ForeColor="#808080"></asp:Label>
                <asp:RadioButton ID="rb_stu" runat="server" Text="学生"
                    GroupName="identity" />
                <asp:RadioButton ID="rb_tea" runat="server" Text="教师"
                    GroupName="identity" />
            </asp:Panel>
            <asp:Panel ID="p_namePwd" runat="server" HorizontalAlign="Center" CssClass="pa">
                <asp:Label ID="Label2" runat="server" Text="用户名" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="u_id" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="新密码" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="u_pwd" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label1" runat="server" Text="确认密码" CssClass="lbl"></asp:Label>
                <asp:TextBox ID="u_checkPwd" runat="server"></asp:TextBox>
            </asp:Panel>
            <div class="div_btn">
                <asp:Button ID="btn_submit" runat="server" Text="提交" OnClick="btn_submit_Click" Width="213px" BackColor="DodgerBlue" BorderWidth="0px" ForeColor="White" Height="30px" Font-Size="Medium" />
                </div>
            <div class="div_btn">
                <asp:Button ID="Button1" runat="server" Text="返回登录" OnClick="Button1_Click" Width="213px" BackColor="#cccccc" BorderWidth="0px" ForeColor="White" Height="30px" Font-Size="Medium" />
            </div>
            <div>
                <div class="tip">
                    <asp:Label ID="lblTip" ForeColor="#FF6600" runat="server" Height="30px">用户名一般为学号或编号</asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
