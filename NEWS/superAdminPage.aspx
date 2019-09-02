<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="superAdminPage.aspx.cs" Inherits="NEWS.superAdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>NEWS-超级管理员</title>
    <style type="text/css">
        * {
            font-family: 微软雅黑,Consolas;
        }

        #navigation {
            margin-top: 20px;
            border-bottom: solid 1px #0094ff;
            border-top: solid 1px #0094ff;
            height: 40px;
            width: 1000px;
        }

        #mydescription {
            position: absolute;
            bottom: 0px;
        }

        #top_left {
            position: relative;
        }

        #content_a_manage {
            margin:30px auto 0 auto;
            width:900px;

        }

        .btn_navigation {
            width: 150px;
            height: 40px;
            font-size: medium;
            background-color: white;
            border: 0px;
        }

        #sname {
            margin: 20px 0px 0px 10px;
        }

        table td {
            overflow: auto;
            max-width: 200px;
        }

        #GridView1 {
            width: 900px;
        }

        .lbl_1 {
            color: #808080;
        }

        #Label2, #Label3 {
            margin-right: 15px;
        }

        .textBox {
            border: 0px;
            border-bottom: 1px solid #b6b6b6;
        }

        .btn {
            width: 250px;
            display: block;
            text-align: center;
            margin-top: 20px;
        }
    </style>
</head>
<body style="width: 1000px; margin: 0 auto;">
    <form id="form1" runat="server">
        <div>
            <div id="top">
                <div id="top_left">
                    <asp:Label ID="sname" runat="server" Text="姓名" Height="50px"></asp:Label>
                    <asp:Label ID="mydescription" runat="server" Text="个人签名"></asp:Label>
                </div>
                <div id="navigation">
                    <asp:Button ID="btn_a_manage" runat="server" Text="管理管理员" OnClick="btn_a_manage_Click" CausesValidation="False" CssClass="btn_navigation"></asp:Button>
                    <asp:Button ID="btn_a_addManager" runat="server" Text="添加管理员" OnClick="btn_a_addManager_Click" CausesValidation="False" CssClass="btn_navigation"></asp:Button>
                </div>
            </div>
        </div>
        <div id="content_a_add" runat="server" style="width: 300px; overflow: visible; margin: 20px auto; line-height: 30px;">
            <asp:Label ID="Label1" runat="server" Text="用户名" CssClass="lbl_1"></asp:Label>
            <asp:TextBox ID="txt_id" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_name" runat="server" ErrorMessage="*" ControlToValidate="txt_name" ForeColor="#FF9900"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="密码" CssClass="lbl_1"></asp:Label>
            <asp:TextBox ID="txt_pwd" runat="server" CssClass="textBox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_pwd" runat="server" ErrorMessage="*" ControlToValidate="txt_pwd" ForeColor="#FF9900"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label3" runat="server" Text="姓名" CssClass="lbl_1"></asp:Label>
            <asp:TextBox ID="txt_name" runat="server" CssClass="textBox"></asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="出生日期" CssClass="lbl_1"></asp:Label>
            <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
            <asp:Label ID="Label11" runat="server" Text="年"></asp:Label>
            <asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>
            <asp:Label ID="Label12" runat="server" Text="月"></asp:Label>
            <asp:DropDownList ID="ddlDay" runat="server"></asp:DropDownList>
            <asp:Label ID="Label13" runat="server" Text="日"></asp:Label>
            <br />
            <asp:Label ID="Label10" runat="server" Text="个性签名" CssClass="lbl_1"></asp:Label><br />
            <asp:TextBox ID="txt_description" runat="server" TextMode="MultiLine" Height="100px" Width="250px" MaxLength="500" BorderWidth="1px" BorderColor="Gray"></asp:TextBox><br />

            <div class="btn">
                <asp:Button ID="btn_register" OnClick="btn_register_Click" runat="server" Text="注册" Width="213px" BackColor="DodgerBlue" BorderWidth="0px" ForeColor="White" Height="30px" Font-Size="Medium" />
                <br />
                <asp:Label ID="lbl_add_tip" runat="server" ForeColor="#FF6600" Text=""></asp:Label>
            </div>
        </div>
        <div id="content_a_manage" runat="server">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
                OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="si_id" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="u_object" HeaderText="用户身份" ReadOnly="true"/>
                    <asp:BoundField DataField="u_id" HeaderText="用户名" />
                    <asp:BoundField DataField="pwd" HeaderText="密码" />
                    <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                </Columns>
                <RowStyle BackColor="White" BorderStyle="None" Height="25px" HorizontalAlign="Center" />
                <EditRowStyle BackColor="#99C89D" />
                <PagerStyle BackColor="White" ForeColor="#0066FF" HorizontalAlign="Center" BorderStyle="Solid" />
                <HeaderStyle BackColor="#0066FF" Font-Bold="True" ForeColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center" Wrap="False" />
            </asp:GridView>
            <asp:Label ID="lbl_tip_manage" runat="server" ForeColor="#FF6600" Text=""></asp:Label>
        </div>
        <div id="div_back" style="margin-top:200px;">
            <asp:Button ID="btnBack" OnClick="btnBack_Click" Text="退出" runat="server" CausesValidation="false" Width="113px" BackColor="#CCCCCC" BorderWidth="0px" ForeColor="White" Height="30px" Font-Size="Medium" ></asp:Button>
        </div>
    </form>
</body>
</html>
