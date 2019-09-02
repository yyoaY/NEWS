using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NEWS
{
    public partial class teacherPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) Session["isPublishNews"] = "false";//第一次打开，设置session
            
            if (Session["u_id"] != null)//判断是否登录
            {
                //已登录->初始化数据
                InitTableData();//我收到的消息/我发布的消息表格
                if (!IsPostBack)
                {
                    InitReceiverList();//选择接收者列表
                }
            }
            else
            {
                Response.Redirect("Login.aspx");//返回到登录页面
            }

            //从数据库获得姓名/个性签名
            String sql = "select t_name,mydescription from tea where t_id='" + Session["u_id"] + "';";
            SqlDataReader sqlDr = dataOperate.getRow(sql);
            if (sqlDr.Read())
            {//设置姓名/个性签名
                sname.Text = sqlDr.GetValue(0).ToString();
                mydescription.Text = sqlDr.GetValue(1).ToString();
            }

            //打开默认在“我的消息”模块
            hideAll();
            if (Session["isPublishNews"].ToString().Trim() == "true")
            {
                content_t_publishNews.Visible = true;
            }
            else
            {
                content_t_mynews.Visible = true;
            }
            SetButtonBackColor();
        }

        private void InitReceiverList()
        {//初始化接收者列表cbl_receiver，为其添加项

            //在数据库安全信息表获得所有学生的信息（s_id,s_name）
            String sql = "select s_id,s_name from securityInfo,stu where u_id=s_id ";
            SqlDataReader sqlDr = dataOperate.getRow(sql);
            while (sqlDr.Read())
            {
                String id = sqlDr.GetValue(0).ToString();
                String name = sqlDr.GetValue(1).ToString();
                //添加项
                cbl_receiver.Items.Add(id + "|" + name);
            }
        }

        private void InitTableData()
        {
            //清除原记录
            table_receive.Rows.Clear();
            table_published.Rows.Clear();
            //表头
            TableHeaderCell thc0 = new TableHeaderCell();
            TableHeaderCell thc1 = new TableHeaderCell();
            TableHeaderCell thc2 = new TableHeaderCell();
            TableHeaderCell thc3 = new TableHeaderCell();
            TableHeaderCell thc4 = new TableHeaderCell();
            thc0.Text = "时间";
            thc1.Text = "发布者";
            thc2.Text = "标题";
            thc3.Text = "内容";
            thc4.Text = "状态";
            TableHeaderRow thr = new TableHeaderRow();
            thr.Cells.Add(thc0);
            thr.Cells.Add(thc1);
            thr.Cells.Add(thc2);
            thr.Cells.Add(thc3);
            thr.Cells.Add(thc4);
            thr.CssClass = "TableHeadRow";
            table_receive.Rows.Add(thr);

            TableHeaderCell thc20 = new TableHeaderCell();
            TableHeaderCell thc21 = new TableHeaderCell();
            TableHeaderCell thc22 = new TableHeaderCell();
            TableHeaderCell thc23 = new TableHeaderCell();
            TableHeaderCell thc24 = new TableHeaderCell();
            TableHeaderCell thc25 = new TableHeaderCell();
            thc20.Text = "时间";
            thc21.Text = "标题";
            thc22.Text = "内容";
            thc23.Text = "学号";
            thc24.Text = "姓名";
            thc25.Text = "状态";
            TableHeaderRow thr2 = new TableHeaderRow();
            thr2.Cells.Add(thc20);
            thr2.Cells.Add(thc21);
            thr2.Cells.Add(thc22);
            thr2.Cells.Add(thc23);
            thr2.Cells.Add(thc24);
            thr2.Cells.Add(thc25);
            thr2.CssClass = "TableHeadRow";
            table_published.Rows.Add(thr2);


            //我收到的消息(时间，发布者，标题，内容，状态)
            //String n_time = "", publishedBy = "", n_title = "", n_content = "", n_state = "";
            String sql = "select n_time,publishedBy,n_title,n_content,n_state from newsInfo where receiver='" + Session["u_id"] + "' order by n_time desc";
            SqlDataReader sqlDr = dataOperate.getRow(sql);
            while (sqlDr.Read())
            {
                TableCell tc0 = new TableCell();
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();
                tc0.Text = sqlDr.GetValue(0).ToString();
                tc1.Text = sqlDr.GetValue(1).ToString();
                tc2.Text = sqlDr.GetValue(2).ToString();
                tc3.Text = sqlDr.GetValue(3).ToString();
                tc4.Text = sqlDr.GetValue(4).ToString();
                

                TableRow tr = new TableRow();
                tr.Cells.Add(tc0);
                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);
                tr.Cells.Add(tc3);
                tr.Cells.Add(tc4);

                table_receive.Rows.Add(tr);

            }



            //我发布的消息(时间，标题，内容,接收者id,接收者name,状态)
            sql = "select n_time,n_title,n_content,receiver,s_name,n_state from newsInfo,stu where receiver=s_id and publishedBy='" + Session["u_id"] + "' order by n_time desc";
            sqlDr = dataOperate.getRow(sql);
            while (sqlDr.Read())
            {
                TableCell tc0 = new TableCell();
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();
                TableCell tc5 = new TableCell();
                tc0.Text = sqlDr.GetValue(0).ToString();
                tc1.Text = sqlDr.GetValue(1).ToString();
                tc2.Text = sqlDr.GetValue(2).ToString();
                tc3.Text = sqlDr.GetValue(3).ToString();
                tc4.Text = sqlDr.GetValue(4).ToString();
                tc5.Text = sqlDr.GetValue(5).ToString();

                TableRow tr = new TableRow();
                tr.Cells.Add(tc0);
                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);
                tr.Cells.Add(tc3);
                tr.Cells.Add(tc4);
                tr.Cells.Add(tc5);

                table_published.Rows.Add(tr);
            }
        }

        protected void btn_t_myNews_Click(object sender, EventArgs e)
        {//我的消息
            //显示模块
            hideAll();
            content_t_mynews.Visible = true;
            SetButtonBackColor();
        }

        private void SetButtonBackColor()
        {//修改颜色

            if (content_t_mynews.Visible == true)
            {
                btn_t_myNews.BackColor = Color.DodgerBlue;
            }
            else
            {
                btn_t_myNews.BackColor = Color.White;
            }
            if (content_t_publishNews.Visible == true)
            {
                btn_t_publishNews.BackColor = Color.DodgerBlue;
            }
            else
            {
                btn_t_publishNews.BackColor = Color.White;
            }
        }

        private void hideAll()
        {//隐藏所有模块
            content_t_mynews.Visible = false;
            content_t_publishNews.Visible = false;
        }

        protected void btn_t_publishNews_Click(object sender, EventArgs e)
        {//发布消息
            //初始化
            InitContent_t_publishNews();
            //显示模块
            hideAll();
            content_t_publishNews.Visible = true;
            Session["isPublishNews"] = "true";

            SetButtonBackColor();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            //判断是否选择接收者
            if (cbl_receiver.SelectedValue != "")
            {
                bool b = false;
                for (int i = 0; i < cbl_receiver.Items.Count; i++)//遍历每一项
                {
                    if (cbl_receiver.Items[i].Selected)//是否被选择
                    {//被选择
                        //获取id,name
                        String str = cbl_receiver.Items[i].Value;
                        String[] s = str.Split('|');//s[0]-id;s[1]-name

                        //写入数据库
                        String sql = "insert into newsInfo(n_title,n_content,n_time,publishedBy,receiver,n_state) values('"
                            + tb_publish_title.Text.Trim() + "','" + tb_publish_content.Text.Trim() + "','" + date
                            + "','" + Session["u_id"] + "','" + s[0].Trim() + "','未读');";

                        b = dataOperate.execSQL(sql);
                    }
                }
                if (b)
                {
                    lbl_publish_tip.Text = "发布成功！";
                }
                else
                {
                    lbl_publish_tip.Text = "发布失败！";
                }
            }
            else
            {
                lbl_publish_tip.Text = "未选择消息接收者！";
            }

            SetButtonBackColor();

        }

        private void InitContent_t_publishNews()
        {//初始化“发布消息”模块
            //清空文本框和提示
            tb_publish_title.Text = "";
            tb_publish_content.Text = "";
            lbl_publish_tip.Text = "";
            for (int i = 0; i < cbl_receiver.Items.Count; i++)//遍历每一项
            {
                cbl_receiver.Items[i].Selected = false;//取消所有选择
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //跳转到登录界面
            Response.Redirect("Login.aspx");
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            string sqlstr = "update newsInfo set n_state='已读' where receiver='"
                                        + Session["u_id"] + "'";

            if (dataOperate.execSQL(sqlstr))
            {
                lbl_tip.Text = "操作完成！";
                
                InitTableData();
            }
            else
                lbl_tip.Text = "操作失败！";
        }

    }
}