using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NEWS
{
    public partial class adminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //第一次打开设置session;用于判断是否打开XX模块
                Session["isPublish"] = "false";
                Session["isManage"] = "false";
            }

            if (Session["u_id"] != null)//判断是否登录
            {
                //已登录
                if (!IsPostBack)
                {
                    //初始化接收者对象
                    InitReceiverList();
                }
                //从数据库获得姓名/个性签名
                String sql = "select a_name,mydescription from newsAdmin where a_id='" + Session["u_id"] + "';";
                SqlDataReader sqlDr = dataOperate.getRow(sql);
                if (sqlDr.Read())
                {//设置姓名/个性签名
                    sname.Text = sqlDr.GetValue(0).ToString();
                    mydescription.Text = sqlDr.GetValue(1).ToString();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");//返回到登录页面
            }



            //打开默认在“查看消息”模块
            HideAll();
            if (Session["isPublish"].ToString().Trim() == "true")
            {
                div_publishNews.Visible = true;
                //InitPublishNews();//初始化模块
            }
            else if (Session["isManage"].ToString().Trim() == "true")
            {
                div_manageData.Visible = true;
                InitManageData();//初始化模块
            }
            else
            {
                div_checkNews.Visible = true;
                InitCheckNews();//初始化模块
            }
            SetButtonBackColor();
        }

        /// <summary>
        /// 设置"发布消息"模块的接收者对象
        /// </summary>
        private void InitReceiverList()
        {//初始化接收者列表cbl_receiver，为其添加项
            //若存在项，清空所有项
            cbl_a_receiver.Items.Clear();
            //在数据库安全信息表获得所有学生的信息（s_id,s_name）
            String sql = "select s_id,s_name from securityInfo,stu where u_id=s_id; ";
            SqlDataReader sqlDr = dataOperate.getRow(sql);
            while (sqlDr.Read())
            {
                String id = sqlDr.GetValue(0).ToString();
                String name = sqlDr.GetValue(1).ToString();
                //添加项
                cbl_a_receiver.Items.Add(id + "|" + name);
            }

            //在数据库安全信息表获得所有教师的信息（t_id,t_name）
            sql = "select t_id,t_name from securityInfo,tea where u_id=t_id; ";
            sqlDr = dataOperate.getRow(sql);
            while (sqlDr.Read())
            {
                String id = sqlDr.GetValue(0).ToString();
                String name = sqlDr.GetValue(1).ToString();
                //添加项
                cbl_a_receiver.Items.Add(id + "|" + name);
            }
        }

        /// <summary>
        /// 初始化“查看消息”模块
        /// </summary>
        private void InitCheckNews()
        {
            bind_myPublish_CheckNews();

            bind_others_CheckNews();

        }
        private void bind_myPublish_CheckNews()
        {
            //我发布的消息
            string sqlstr = "select * from newsInfo where publishedBy='" + Session["u_id"] + "'";//
            DataSet myds = dataOperate.getDataset(sqlstr);
            gv_checkNews_myPublish.DataSource = myds;
            gv_checkNews_myPublish.DataKeyNames = new string[] { "ni_id" };//主键
            gv_checkNews_myPublish.DataBind();
        }

        private void bind_others_CheckNews()
        {
            //其他消息
            string sqlstr = "select * from newsInfo where publishedBy!='" + Session["u_id"] + "'";//
            DataSet myds = dataOperate.getDataset(sqlstr);
            gv_checkNews_otherNews.DataSource = myds;
            gv_checkNews_otherNews.DataKeyNames = new string[] { "ni_id" };//主键
            gv_checkNews_otherNews.DataBind();
        }


        /// <summary>
        /// 初始化“发布消息”模块
        /// </summary>
        private void InitPublishNews()
        {
            //清空文本框和提示
            tb_p_title.Text = "";
            tb_p_content.Text = "";
            lbl_tip_publishNews.Text = "";
            for (int i = 0; i < cbl_a_receiver.Items.Count; i++)//遍历每一项
            {
                cbl_a_receiver.Items[i].Selected = false;//取消所有选择
            }
        }

        /// <summary>
        /// 初始化“管理数据”模块
        /// </summary>
        private void InitManageData()
        {

        }

        /// <summary>
        /// 修改导航栏按钮背景颜色
        /// </summary>
        private void SetButtonBackColor()
        {
            if (div_checkNews.Visible == true)
            {
                btn_a_checkNews.BackColor = Color.DodgerBlue;
            }
            else
            {
                btn_a_checkNews.BackColor = Color.White;
            }
            if (div_manageData.Visible == true)
            {
                btn_a_manageData.BackColor = Color.DodgerBlue;
            }
            else
            {
                btn_a_manageData.BackColor = Color.White;
            }

            if (div_publishNews.Visible == true)
            {
                btn_a_publishNews.BackColor = Color.DodgerBlue;
            }
            else
            {
                btn_a_publishNews.BackColor = Color.White;
            }
        }

        /// <summary>
        /// 隐藏所有模块
        /// </summary>
        private void HideAll()
        {
            div_publishNews.Visible = false;
            div_manageData.Visible = false;
            div_checkNews.Visible = false;
        }

        /// <summary>
        /// "查看消息"按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_a_checkNews_Click(object sender, EventArgs e)
        {
            //设置session
            Session["isPublish"] = "false";
            Session["isManage"] = "false";
            //初始化
            InitCheckNews();
            //显示模块
            HideAll();
            div_checkNews.Visible = true;
            //按钮颜色
            SetButtonBackColor();

        }

        /// <summary>
        /// "发布消息"按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_a_publishNews_Click(object sender, EventArgs e)
        {
            //设置session
            Session["isPublish"] = "true";
            Session["isManage"] = "false";
            //初始化
            InitPublishNews();
            //显示模块
            HideAll();
            div_publishNews.Visible = true;
            //按钮颜色
            SetButtonBackColor();
        }

        /// <summary>
        /// "管理数据"按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_a_manageData_Click(object sender, EventArgs e)
        {
            //设置session
            Session["isPublish"] = "false";
            Session["isManage"] = "true";
            //初始化
            InitManageData();
            //显示模块
            HideAll();
            div_manageData.Visible = true;
            //按钮颜色
            SetButtonBackColor();
        }

        /// <summary>
        /// "发布消息"模块-发布按钮 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_publish_publishNews_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            //判断是否选择接收者
            Response.Write("//" + cbl_a_receiver.SelectedValue);
            if (cbl_a_receiver.SelectedValue != "")
            {
                bool b = false;//用于判断是否发布成功

                for (int i = 0; i < cbl_a_receiver.Items.Count; i++)//遍历每一项
                {
                    if (cbl_a_receiver.Items[i].Selected)//是否被选择
                    {//被选择
                        //获取id,name
                        String str = cbl_a_receiver.Items[i].Value;
                        String[] s = str.Split('|');//s[0]-id;s[1]-name

                        //写入数据库
                        String sql = "insert into newsInfo(n_title,n_content,n_time,publishedBy,receiver,n_state) values('"
                            + tb_p_title.Text.Trim() + "','" + tb_p_content.Text.Trim() + "','" + date
                            + "','" + Session["u_id"] + "','" + s[0].Trim() + "','未读');";

                        b = dataOperate.execSQL(sql);
                        
                    }
                }
                if (b)
                {
                    lbl_tip_publishNews.Text = "发布成功！";

                }
                else
                {
                    lbl_tip_publishNews.Text = "发布失败！";
                }
            }
            else
            {
                lbl_tip_publishNews.Text = "未选择消息接收者！";
            }
        }

        /// <summary>
        /// “查看消息”模块-我发布的消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_checkNews_myPublish_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_checkNews_myPublish.PageIndex = e.NewPageIndex;
            bind_myPublish_CheckNews();
        }

        protected void gv_checkNews_myPublish_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_checkNews_myPublish.EditIndex = e.NewEditIndex;
            bind_myPublish_CheckNews();
        }

        //删除
        protected void gv_checkNews_myPublish_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bool a = false;
            //删除newsInfo表中记录
            string sqlstr = "delete from newsInfo where ni_id='" + gv_checkNews_myPublish.DataKeys[e.RowIndex].Value.ToString() + "'";
            a = dataOperate.execSQL(sqlstr);
            if (a)
            {
                lbl_tip_checkNews_myPublish.Text = "删除成功！";
            }
            else
            {
                lbl_tip_checkNews_myPublish.Text = "删除失败！";
            }
            bind_myPublish_CheckNews();
        }

        //更新
        protected void gv_checkNews_myPublish_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool a = false;
            string sqlstr = "update newsInfo set n_title='"
                + ((TextBox)(gv_checkNews_myPublish.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim() + "',n_content='"
                + ((TextBox)(gv_checkNews_myPublish.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim() + "',publishedBy='"
                + ((TextBox)(gv_checkNews_myPublish.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim() + "',receiver='"
                + ((TextBox)(gv_checkNews_myPublish.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim() + "',n_state='"
                + ((TextBox)(gv_checkNews_myPublish.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim() + "' where ni_id='"
                + gv_checkNews_myPublish.DataKeys[e.RowIndex].Value.ToString() + "'";
            a = dataOperate.execSQL(sqlstr);

            Response.Write(sqlstr);

            gv_checkNews_myPublish.EditIndex = -1;

            if (a)
                lbl_tip_checkNews_myPublish.Text = "更改成功！";
            else
                lbl_tip_checkNews_myPublish.Text = "更改失败！";

            bind_myPublish_CheckNews();
        }

        //取消
        protected void gv_checkNews_myPublish_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_checkNews_myPublish.EditIndex = -1;
            bind_myPublish_CheckNews();
        }

        //others

        protected void gv_checkNews_otherNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_checkNews_otherNews.PageIndex = e.NewPageIndex;
            bind_others_CheckNews();
        }

        protected void gv_checkNews_otherNews_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_checkNews_otherNews.EditIndex = e.NewEditIndex;
            bind_others_CheckNews();
        }

        //删除
        protected void gv_checkNews_otherNews_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bool a = false;
            //删除newsInfo表中记录
            string sqlstr = "delete from newsInfo where ni_id='" + gv_checkNews_otherNews.DataKeys[e.RowIndex].Value.ToString() + "'";
            a = dataOperate.execSQL(sqlstr);
            if (a)
            {
                lbl_tip_otherNews.Text = "删除成功！";
            }
            else
            {
                lbl_tip_otherNews.Text = "删除失败！";
            }
            bind_others_CheckNews();
        }

        //更新
        protected void gv_checkNews_otherNews_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool a = false;
            string sqlstr = "update newsInfo set n_time='"
                + ((TextBox)(gv_checkNews_otherNews.Rows[e.RowIndex].Cells[0].Controls[0])).Text.ToString().Trim() + "',n_title='"
                + ((TextBox)(gv_checkNews_otherNews.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim() + "',n_content='"
                + ((TextBox)(gv_checkNews_otherNews.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim() + "',publishedBy='"
                + ((TextBox)(gv_checkNews_otherNews.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim() + "',receiver='"
                + ((TextBox)(gv_checkNews_otherNews.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim() + "',n_state='"
                + ((TextBox)(gv_checkNews_otherNews.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim() + "' where ni_id='"
                + gv_checkNews_otherNews.DataKeys[e.RowIndex].Value.ToString() + "'";
            a = dataOperate.execSQL(sqlstr);

            gv_checkNews_otherNews.EditIndex = -1;

            if (a)
                lbl_tip_otherNews.Text = "更改成功！";
            else
                lbl_tip_otherNews.Text = "更改失败！";

            bind_others_CheckNews();
        }

        //取消
        protected void gv_checkNews_otherNews_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_checkNews_otherNews.EditIndex = -1;
            bind_others_CheckNews();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //跳转到登录界面
            Response.Redirect("Login.aspx");
        }

    }
}