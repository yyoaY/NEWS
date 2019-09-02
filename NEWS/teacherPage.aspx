<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacherPage.aspx.cs" Inherits="NEWS.teacherPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>NEWS-教师</title>
    <style type="text/css">
        * {
            font-family: 微软雅黑,Consolas;
        }

        #mydescription {
            position: absolute;
            bottom: 0px;
        }

        #top_left {
            position: relative;
        }

        #content {
            margin-top: 50px;
        }

        .TableHeadRow {
            border-bottom: solid 1px #0094ff;
            background-color: #0066FF;
            color: white;
        }

        #table_receive, #table_published {
            width: 900px;
            margin: 10px auto 10px auto;
            border: 0;
        }


        #content_t_mynews, #content_t_publishNews {
            margin-top: 20px;
        }

        #content_t_publishNews {
            width: 299px;
            margin: 20px auto;
        }

        #ctp_editContent, #ctp_choiceReceiver {
            width: 299px;
        }

        #ctp_content {
            width: 299px;
            line-height: 30px;
        }

        #ctp_btn, #ctp_lblTip {
            width: 299px;
            display: block;
            text-align: center;
            margin-top: 20px;
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

        #sname {
            margin: 20px 0px 0px 10px;
        }

        .lbl_content {
            display: block;
        }

        td {
            max-width: 200px;
            overflow: auto;
        }

        .textBox {
            border: 0px;
            border-bottom: 1px solid #b6b6b6;
        }
        .lbl {
            margin: 0 auto 5px auto;
            width:900px;
            color:#808080;
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
                    <asp:Button ID="btn_t_myNews" runat="server" Text="我的消息" OnClick="btn_t_myNews_Click" CausesValidation="False" CssClass="btn_navigation"></asp:Button>
                    <asp:Button ID="btn_t_publishNews" runat="server" Text="发布消息" OnClick="btn_t_publishNews_Click" CausesValidation="False" CssClass="btn_navigation"></asp:Button>
                </div>

            </div>
        </div>
        <div id="content_t_mynews" runat="server">
        <div class="lbl">
                <asp:Label runat="server" Text="我收到的消息"></asp:Label>
        </div>
            <asp:Table ID="table_receive" runat="server" CaptionAlign="Left" CellPadding="4">
                <asp:TableHeaderRow CssClass="TableHeadRow">
                    <asp:TableHeaderCell>
                        时间
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        发布者
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        标题
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        内容
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        状态
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <div style="text-align: right; margin:5px auto;width:900px;">
                        <asp:Button ID="btnRead" OnClick="btnRead_Click" Text="全部已读" runat="server" CausesValidation="false" Width="113px" BackColor="#99CCFF" BorderWidth="0px" ForeColor="#0066FF" Height="30px" Font-Size="Small" BorderStyle="None"></asp:Button>
                    </div>
            <div style="margin:0px auto 30px;width:900px;">
            <asp:Label runat="server" ID="lbl_tip" ForeColor="#FF6600"></asp:Label>
            </div>
            
        <div class="lbl">
                <asp:Label runat="server" Text="我发布的消息"></asp:Label>
        </div>
            <asp:Table ID="table_published" runat="server" CaptionAlign="Left" CellPadding="4">
                <asp:TableHeaderRow CssClass="TableHeadRow">
                    <asp:TableHeaderCell>
                        时间
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        标题
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        内容
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        学号
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        姓名
                    </asp:TableHeaderCell>
                    <asp:TableHeaderCell>
                        状态
                    </asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
        <div id="content_t_publishNews" runat="server">
            <div id="ctp_content">
                <div id="ctp_editContent">
                    <asp:Label ID="Label1" runat="server" Text="标题" Style="color: #808080;"></asp:Label>
                    <asp:TextBox ID="tb_publish_title" runat="server" ToolTip="在此输入消息标题" CssClass="textBox" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_publish_title" runat="server" ErrorMessage="*" Display="Static" ControlToValidate="tb_publish_title" ForeColor="#FF6600" Height="20px"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="内容" Style="color: #808080;" CssClass="lbl_content"></asp:Label>
                    <asp:TextBox ID="tb_publish_content" runat="server" TextMode="MultiLine" ToolTip="在此输入消息内容" Height="100px" Width="285px" MaxLength="500" BorderWidth="1px" BorderColor="Gray"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_publish_content" runat="server" ErrorMessage="*" Display="Static" ControlToValidate="tb_publish_content" ForeColor="#FF6600"></asp:RequiredFieldValidator>
                </div>
                <div id="ctp_choiceReceiver">
                    <asp:Label ID="Label3" runat="server" Text="选择接收者" Style="color: #808080;"></asp:Label>
                    <asp:CheckBoxList ID="cbl_receiver" runat="server">
                    </asp:CheckBoxList>
                </div>
            </div>
            <div id="ctp_btn">
                <asp:Button ID="Button1" runat="server" Text="发布" OnClick="Button1_Click" Width="213px" BackColor="DodgerBlue" BorderWidth="0px" ForeColor="White" Height="30px" Font-Size="Medium" />
            </div>
            <div id="ctp_lblTip">
                <asp:Label ID="lbl_publish_tip" runat="server" ForeColor="#FF6600" Text=""></asp:Label>
            </div>

        </div>
        <div id="div_back" style="margin-top:200px;">
            <asp:Button ID="btnBack" OnClick="btnBack_Click" Text="退出" runat="server" CausesValidation="false" Width="113px" BackColor="#CCCCCC" BorderWidth="0px" ForeColor="White" Height="30px" Font-Size="Medium" ></asp:Button>
        </div>
    </form>
</body>
</html>
