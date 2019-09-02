<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="NEWS.adminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>NEWS-ADMIN</title>
    <style type="text/css">
        * {
            font-family: 微软雅黑,Consolas;
        }

        #top_left, #content, #navigation {
            width: 1000px;
            margin: 20px auto;
        }

        #top_left {
            position: relative;
        }

        #sname {
            margin: 20px 0px 0px 10px;
        }

        #mydescription {
            position: absolute;
            bottom: 0px;
        }

        #content_a_manage {
            margin-top: 30px;
        }

        .btn_navigation {
            width: 150px;
            height: 40px;
            font-size: medium;
            background-color: white;
            border: 0px;
        }

        #navigation {
            margin-top: 20px;
            border-bottom: solid 1px #0094ff;
            border-top: solid 1px #0094ff;
            height: 40px;
            width: 1000px;
        }

        table td {
            overflow: auto;
            max-width: 200px;
        }


        #p_btn, #p_lblTip {
            width: 299px;
            display: block;
            text-align: center;
            margin-top: 20px;
        }

        .lbl {
            margin: 0 auto 5px auto;
            width: 900px;
            color: #808080;
        }

        .textBox {
            border: 0px;
            border-bottom: 1px solid #b6b6b6;
        }
        #p_content{
            line-height: 30px;
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
                    <asp:Button ID="btn_a_checkNews" runat="server" Text="查看消息" OnClick="btn_a_checkNews_Click" CausesValidation="False" CssClass="btn_navigation"></asp:Button>
                    <asp:Button ID="btn_a_publishNews" runat="server" Text="发布消息" OnClick="btn_a_publishNews_Click" CausesValidation="False" CssClass="btn_navigation"></asp:Button>
                    <asp:Button ID="btn_a_manageData" runat="server" Text="管理数据" OnClick="btn_a_manageData_Click" CausesValidation="False" CssClass="btn_navigation"></asp:Button>
                </div>
            </div>
        </div>
        <div id="div_checkNews" runat="server">
            <div class="lbl">
                <asp:Label runat="server" Text="我发布的消息"></asp:Label>
            </div>
            <div style="margin: 0 auto 20px auto; width: 900px; overflow: visible;">
                <asp:GridView ID="gv_checkNews_myPublish" runat="server" Width="900px" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" OnRowDeleting="gv_checkNews_myPublish_RowDeleting" OnRowEditing="gv_checkNews_myPublish_RowEditing"
                    OnRowUpdating="gv_checkNews_myPublish_RowUpdating" OnRowCancelingEdit="gv_checkNews_myPublish_RowCancelingEdit">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="n_time" HeaderText="时间" ReadOnly="True" />
                        <asp:BoundField DataField="n_title" HeaderText="标题" />
                        <asp:BoundField DataField="n_content" HeaderText="内容" />
                        <asp:BoundField DataField="publishedBy" HeaderText="发布者" />
                        <asp:BoundField DataField="receiver" HeaderText="接收者" />
                        <asp:BoundField DataField="n_state" HeaderText="状态" />
                        <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                    <RowStyle BackColor="White" BorderStyle="None" Height="25px" HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#99C89D" />
                        <SelectedRowStyle BackColor="#6699FF" Font-Bold="True" ForeColor="White" BorderStyle="Dashed" />
                        <PagerStyle BackColor="White" ForeColor="#0066FF" HorizontalAlign="Center" BorderStyle="Solid" />
                        <HeaderStyle BackColor="#0066FF" Font-Bold="True" ForeColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center" Wrap="False" />
                </asp:GridView>
                <asp:Label ID="lbl_tip_checkNews_myPublish" ForeColor="#FF6600" runat="server" Text=""></asp:Label>
            </div>
            <div class="lbl">
                <asp:Label runat="server" Text="其他消息"></asp:Label>
            </div>
            <div style="margin: 0 auto; width: 900px; overflow: visible;">
                <asp:GridView ID="gv_checkNews_otherNews" runat="server" Width="900px" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" OnRowDeleting="gv_checkNews_otherNews_RowDeleting" OnRowEditing="gv_checkNews_otherNews_RowEditing"
                    OnRowUpdating="gv_checkNews_otherNews_RowUpdating" OnRowCancelingEdit="gv_checkNews_otherNews_RowCancelingEdit">
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <Columns>
                        <asp:BoundField DataField="n_time" HeaderText="时间" ReadOnly="True" />
                        <asp:BoundField DataField="n_title" HeaderText="标题" />
                        <asp:BoundField DataField="n_content" HeaderText="内容" />
                        <asp:BoundField DataField="publishedBy" HeaderText="发布者" />
                        <asp:BoundField DataField="receiver" HeaderText="接收者" />
                        <asp:BoundField DataField="n_state" HeaderText="状态" />
                        <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                    <RowStyle BackColor="White" BorderStyle="None" Height="25px" HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#99C89D" />
                        <SelectedRowStyle BackColor="#6699FF" Font-Bold="True" ForeColor="White" BorderStyle="Dashed" />
                        <PagerStyle BackColor="White" ForeColor="#0066FF" HorizontalAlign="Center" BorderStyle="Solid" />
                        <HeaderStyle BackColor="#0066FF" Font-Bold="True" ForeColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center" Wrap="False" />
                </asp:GridView>
                <asp:Label ID="lbl_tip_otherNews" ForeColor="#FF6600" runat="server" Text=""></asp:Label>
            </div>

        </div>
        <div id="div_publishNews" runat="server">
            <div style="margin: 0 auto; width: 299px; overflow: visible;">

                <div id="p_content">
                    <div id="p_editContent">
                        <asp:Label ID="Label1" runat="server" Text="标题" Height="20px" Style="color: #808080;"></asp:Label>
                        <asp:TextBox ID="tb_p_title" runat="server" ToolTip="在此输入消息标题" Height="20px" CssClass="textBox" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_p_title" runat="server" ErrorMessage="*" Display="Static" ControlToValidate="tb_p_title" ForeColor="#FF9900" Height="20px"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="内容" CssClass="lbl_content" Style="color: #808080;"></asp:Label><br />
                        <asp:TextBox ID="tb_p_content" runat="server" TextMode="MultiLine" ToolTip="在此输入消息内容" Height="100px" Width="285px" MaxLength="500" BorderWidth="1px" BorderColor="Gray"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_p_content" runat="server" ErrorMessage="*" Display="Static" ControlToValidate="tb_p_content" ForeColor="#FF9900"></asp:RequiredFieldValidator>
                    </div>
                    <div id="ctp_choiceReceiver">
                        <asp:Label ID="Label3" runat="server" Text="选择接收者" Style="color: #808080;"></asp:Label>
                        <asp:CheckBoxList ID="cbl_a_receiver" runat="server">
                        </asp:CheckBoxList>
                    </div>
                </div>
                <div id="p_btn">
                    <asp:Button ID="btn_publish_publishNews" runat="server" Text="发布" OnClick="btn_publish_publishNews_Click" Width="213px" BackColor="DodgerBlue" BorderWidth="0px" ForeColor="White" Height="30px" Font-Size="Medium" />
                </div>
                <div id="p_lblTip">
                    <asp:Label ID="lbl_tip_publishNews" ForeColor="#FF6600" runat="server" Height="30px"></asp:Label>
                </div>
            </div>
        </div>
        <div id="div_manageData" runat="server">
        </div>
        <div id="div_back" style="margin-top:200px;">
            <asp:Button ID="btnBack" OnClick="btnBack_Click" Text="退出" runat="server" CausesValidation="false" Width="113px" BackColor="#CCCCCC" BorderWidth="0px" ForeColor="White" Height="30px" Font-Size="Medium" ></asp:Button>
        </div>
    </form>
</body>
</html>
