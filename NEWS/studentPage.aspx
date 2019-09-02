<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="studentPage.aspx.cs" Inherits="NEWS.Hello" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>NEWS-学生</title>
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

        td {
            max-width: 200px;
            overflow: auto;
        }
    </style>
</head>
<body style="width: 1000px; margin: 0 auto;">
    <form id="form1" runat="server">
        <div>
            <div id="top">
                <div id="top_left">
                    <asp:Label ID="sname" runat="server" Text="姓名" Height="40px"></asp:Label>
                    <asp:Label ID="mydescription" runat="server" Text="个人签名"></asp:Label>
                </div>
                <div id="navigation">
                    <asp:Button ID="btn_myNews" runat="server" Text="我的消息" CausesValidation="False" CssClass="btn_navigation" BackColor="DodgerBlue"></asp:Button>
                </div>

            </div>
            <div id="content">
                <div style="margin: 0 auto; width: 900px; overflow: visible;">
                    <asp:GridView ID="gvMyNews" runat="server" Width="900px" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" OnRowDataBound="gvMyNews_RowDataBound" OnRowEditing="gvMyNews_RowEditing" OnRowUpdating="gvMyNews_RowUpdating" OnRowCancelingEdit="gvMyNews_RowCancelingEdit">

                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ni_id" ReadOnly="true" Visible="false" />
                            <asp:BoundField HeaderText="时间" DataField="n_time" ReadOnly="true" />
                            <asp:BoundField HeaderText="发布者" DataField="publishedBy" ReadOnly="true" />
                            <asp:BoundField HeaderText="标题" DataField="n_title" ReadOnly="true" />
                            <asp:BoundField HeaderText="内容" DataField="n_content" ReadOnly="true" />
                            <asp:BoundField HeaderText="状态" DataField="n_state" />
                            <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                        </Columns>
                        <RowStyle BackColor="White" BorderStyle="None" Height="25px" HorizontalAlign="Center" />
                        <EditRowStyle BackColor="#99C89D" />
                        <SelectedRowStyle BackColor="#6699FF" Font-Bold="True" ForeColor="White" BorderStyle="Dashed" />
                        <PagerStyle BackColor="White" ForeColor="#0066FF" HorizontalAlign="Center" BorderStyle="Solid" />
                        <HeaderStyle BackColor="#0066FF" Font-Bold="True" ForeColor="White" BorderStyle="None" Height="30px" HorizontalAlign="Center" Wrap="False" />
                    </asp:GridView>
                    <div style="text-align: right; margin-top: 5px;">
                        <asp:Button ID="btnRead" OnClick="btnRead_Click" Text="全部已读" runat="server" CausesValidation="false" Width="113px" BackColor="#99CCFF" BorderWidth="0px" ForeColor="#0066FF" Height="30px" Font-Size="Small" BorderStyle="None"></asp:Button>
                    </div>
                    <asp:Label runat="server" ID="lbl_tip" ForeColor="#FF6600"></asp:Label>
                </div>

            </div>
        </div>
        <div id="div_back" style="margin-top: 200px;">
            <asp:Button ID="btnBack" OnClick="btnBack_Click" Text="退出" runat="server" CausesValidation="false" Width="113px" BackColor="#CCCCCC" BorderWidth="0px" ForeColor="White" Height="30px" Font-Size="Medium"></asp:Button>
        </div>
    </form>
</body>
</html>
