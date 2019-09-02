<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NEWS.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>NEWS-注册</title>
    <style type="text/css">
        * {
            font-family: 微软雅黑,Consolas;
            font-size: medium;
        }

        .top {
            height: 30px;
            text-align: center;
            padding: 30px;
            font-size: larger;
        }

        .content {
            width: 360px;
            margin: 0 auto;
            padding: 10px;
            line-height: 30px;
        }

        .btn {
            width: 213px;
            height: 30px;
            border: 0;
            color: white;
            margin: 4px;
        }

        .div_btn{
            margin:20px auto;
            text-align:center;
        }
        .lbl{
            margin-left:60px;
            color:#808080;
        }
        #div_info{
            width:213px;
            margin:20px auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="top">注册</div>
            <div class="content">
                <asp:Panel ID="p_identity" runat="server" HorizontalAlign="Center">
                    <asp:Label ID="Label1" runat="server" Text="请选择您的身份" ForeColor="#808080"></asp:Label>
                    <asp:RadioButton ID="rb_stu" runat="server" Text="学生"
                        GroupName="identity" />
                    <asp:RadioButton ID="rb_tea" runat="server" Text="教师"
                        GroupName="identity" />
                </asp:Panel>
                <div class="div_btn">
                    <asp:Button ID="btn_rb" runat="server" Text="确定" OnClick="btn_rb_Click" CssClass="btn" BackColor="DodgerBlue" />
                </div>
                <asp:Panel ID="p_teaId" runat="server" Visible="False">
                    <asp:Label ID="Label4" runat="server" Text="编号" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txt_teaId" runat="server"></asp:TextBox>
                </asp:Panel>
                <asp:Panel ID="p_stuId" runat="server" Visible="False">
                    <asp:Label ID="Label5" runat="server" Text="学号" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="txt_stuId" runat="server"></asp:TextBox>
                </asp:Panel>
                <asp:Panel ID="p_namePwd" runat="server" Visible="False">
                    <asp:Label ID="Label2" runat="server" Text="姓名" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="u_name" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="密码" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="u_pwd" runat="server"></asp:TextBox>
                </asp:Panel>

                <asp:Panel ID="p_stuClassInfo" runat="server" Visible="False">
                    <asp:Label ID="Label8" runat="server" Text="班级" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlClass" runat="server"></asp:DropDownList>
                </asp:Panel>

                <asp:Panel ID="p_teaInstitutionInfo" runat="server" Visible="False">
                    <asp:Label ID="Label6" runat="server" Text="学院" CssClass="lbl"></asp:Label>
                    <asp:DropDownList ID="ddlInstitute" runat="server"></asp:DropDownList>
                </asp:Panel>
                <div class="div_btn">
                    <asp:Button ID="btn_impInfo" runat="server" Text="确定" OnClick="btn_impInfo_Click" Visible="false" CssClass="btn" BackColor="DodgerBlue" />
                </div>
                <asp:Panel ID="p_others" runat="server" Visible="False">
                    <asp:Label ID="Label9" runat="server" Text="出生日期" ForeColor="#808080"></asp:Label>
                    <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
                    <asp:Label ID="Label11" runat="server" Text="年"></asp:Label>
                    <asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>
                    <asp:Label ID="Label12" runat="server" Text="月"></asp:Label>
                    <asp:DropDownList ID="ddlDay" runat="server"></asp:DropDownList>
                    <asp:Label ID="Label13" runat="server" Text="日"></asp:Label>
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="个性签名" ForeColor="#808080"></asp:Label><br />
                    <asp:TextBox ID="txt_description" runat="server" TextMode="MultiLine" Width="330px" Height="50px"></asp:TextBox>
                </asp:Panel>
                <div id="div_info" runat="server" visible="false">
                </div>
                <div class="div_btn">
                    <asp:Button ID="btn_info" runat="server" Text="确定" OnClick="btn_info_Click" Visible="false" CssClass="btn" BackColor="DodgerBlue" />
                    <asp:Button ID="btn_modify" runat="server" Text="修改" OnClick="btn_modify_Click" CssClass="btn" BackColor="#CCCCCC" ForeColor="#333333" />
                </div>
                <div class="div_btn">
                    <asp:Button ID="btn_submit" runat="server" Text="提交" OnClick="btn_submit_Click" Width="213px" BackColor="DodgerBlue" BorderWidth="0px" ForeColor="White" Height="30px" Font-Size="Medium" />
                </div>
            </div>
        </div>
    </form>

</body>
</html>
