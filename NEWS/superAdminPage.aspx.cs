using System;

using System.Data;

using System.Configuration;

using System.Web;

using System.Web.Security;

using System.Web.UI;

using System.Web.UI.WebControls;

using System.Web.UI.WebControls.WebParts;

using System.Web.UI.HtmlControls;

using System.Data.SqlClient;
using System.Drawing;

namespace NEWS
{
    public partial class superAdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) Session["isADD"] = "false";//第一次打开，设置session;用于判断是否打开添加模块

            if (Session["u_id"] != null)//判断是否登录
            {
                //已登录->初始化数据

                if (!IsPostBack)
                {
                    bind();
                    InitBirth();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");//返回到登录页面
            }


            //从数据库获得姓名/个性签名
            String sql = "select a_name,mydescription from newsAdmin where a_id='" + Session["u_id"] + "';";
            SqlDataReader sqlDr = dataOperate.getRow(sql);
            if (sqlDr.Read())
            {//设置姓名/个性签名
                sname.Text = sqlDr.GetValue(0).ToString();
                mydescription.Text = sqlDr.GetValue(1).ToString();
            }

            //打开默认在“管理管理员”模块
            HideAll();
            if (Session["isADD"].ToString().Trim() == "true")
            {
                content_a_add.Visible = true;
            }
            else
            {
                content_a_manage.Visible = true;
            }
            SetButtonBackColor();
        }
        private void InitBirth()//出生日期
        {
            for (int i = 1900; i <= 2018; i++)
            {
                ddlYear.Items.Add("" + i);
            }
            for (int i = 1; i <= 12; i++)
            {
                ddlMonth.Items.Add("" + i);
            }
            for (int i = 1; i <= 31; i++)
            {
                ddlDay.Items.Add("" + i);
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }

        //删除
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bool a = false, b = false;
            //删除securityInfo表中记录
            string sqlstr = "delete from securityInfo where si_id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
            a = dataOperate.execSQL(sqlstr);
            //删除newsAdmin表中记录
            sqlstr = "delete from newsAdmin where a_id='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim() + "'";
            b = dataOperate.execSQL(sqlstr);
            if (a && b)
            {
                lbl_tip_manage.Text = "删除成功！";
            }
            else
            {
                lbl_tip_manage.Text = "删除失败！";
            }
            bind();
        }

        //更新
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool a = false;
                string sqlstr = "update securityInfo set u_object='"
                    + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim() + "',u_id='"
                    + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim() + "',pwd='"
                    + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim().GetHashCode() + "' where si_id='"
                    + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
                a = dataOperate.execSQL(sqlstr);

                GridView1.EditIndex = -1;

                if (a)
                    lbl_tip_manage.Text = "更改成功！";
                else
                    lbl_tip_manage.Text = "更改失败！";

            bind();
        }

        //取消
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }

        //绑定
        public void bind()
        {
            string sqlstr = "select * from securityInfo where u_object='管理员' and u_id!='admin'";//
            DataSet myds = dataOperate.getDataset(sqlstr);
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "si_id" };//主键
            GridView1.DataBind();
        }

        protected void btn_a_manage_Click(object sender, EventArgs e)
        {//管理管理员模块
            //显示模块
            HideAll();
            content_a_manage.Visible = true;
            bind();

            SetButtonBackColor();
        }

        protected void btn_a_addManager_Click(object sender, EventArgs e)
        {//添加管理员模块
            //初始化
            InitContent_a_add();
            //显示模块
            HideAll();
            content_a_add.Visible = true;
            Session["isADD"] = "true";

            SetButtonBackColor();
        }

        private void InitContent_a_add()
        {//清空控件
            txt_id.Text = "";
            txt_pwd.Text = "";
            lbl_add_tip.Text = "";
            txt_description.Text = "";
            txt_name.Text = "";
            ddlDay.SelectedIndex = -1;
            ddlMonth.SelectedIndex = -1;
            ddlYear.SelectedIndex = -1;
        }
        private void SetButtonBackColor()
        {//修改颜色

            if (content_a_add.Visible == true)
            {
                btn_a_addManager.BackColor = Color.DodgerBlue;
            }
            else
            {
                btn_a_addManager.BackColor = Color.White;
            }
            if (content_a_manage.Visible == true)
            {
                btn_a_manage.BackColor = Color.DodgerBlue;
            }
            else
            {
                btn_a_manage.BackColor = Color.White;
            }
        }

        private void HideAll()
        {//隐藏所有模块
            content_a_add.Visible = false;
            content_a_manage.Visible = false;

        }

        protected void btn_register_Click(object sender, EventArgs e)
        {//注册一个管理员
            bool a = false, b = false;

            //出生日期
            int year = Convert.ToInt32(ddlYear.Text.Trim());
            int month = Convert.ToInt32(ddlMonth.Text.Trim());
            int day = Convert.ToInt32(ddlDay.Text.Trim());
            DateTime birth = new DateTime(year, month, day);

            //newsAdmin表
            String sql = "insert into newsAdmin(a_id,a_name,birth,mydescription) values('" + txt_id.Text.Trim() + "','" + txt_name.Text.Trim() + "','" + birth + "','" + mydescription.Text.Trim() + "')";
            a = dataOperate.execSQL(sql);

            //securityInfo表
            sql = "insert into securityInfo(u_object,u_id,pwd) values('管理员','" + txt_id.Text.Trim() + "','" + txt_pwd.Text.Trim().GetHashCode() + "')";
            b = dataOperate.execSQL(sql);
            if (a && b)
            {
                lbl_add_tip.Text = "注册成功！";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //跳转到登录界面
            Response.Redirect("Login.aspx");
        }

    }
}