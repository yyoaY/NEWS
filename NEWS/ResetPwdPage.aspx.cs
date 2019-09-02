using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginWeb
{
    public partial class ResetPwdPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["u_id"] != null && Session["identity"] != null)
            {

                //自填充 用户名 和 身份
                if (Session["u_id"].ToString().Trim() != "")
                {
                    u_id.Text = Session["u_id"].ToString().Trim();
                }
                if (Session["identity"].ToString().Trim() != "" && Session["identity"].ToString().Trim() != "管理员")
                {
                    if (rb_stu.Text.Trim() == Session["identity"].ToString().Trim())
                    {
                        rb_stu.Checked = true;
                        rb_tea.Checked = false;
                    }
                    if (rb_tea.Text.Trim() == Session["identity"].ToString().Trim())
                    {
                        rb_tea.Checked = true;
                        rb_stu.Checked = false;
                    }
                }
            }
            //else
            //{
            //    //跳转到登录界面
            //    Response.Redirect("Login.aspx");
            //}
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            //非空验证
            if (!rb_stu.Checked && !rb_tea.Checked)
            {
                lblTip.Text="提交失败，请选择您的身份！";
            }
            else if (u_id.Text.Trim() == "")
            {
                lblTip.Text = "提交失败，请输入用户名！";
            }
            else if (u_pwd.Text.Trim() == "")
            {
                lblTip.Text = "提交失败，请输入密码！";
            }
            else if (u_checkPwd.Text.Trim() == "")
            {
                lblTip.Text = "提交失败，请输入确认密码！";
            }
            else if (u_checkPwd.Text.Trim() != u_pwd.Text.Trim())
            {
                lblTip.Text = "提交失败，确认密码不正确！";
            }
            else 
            {
                //获取身份
                String identity="";
                if (rb_stu.Checked)
                    identity = "学生";
                if (rb_tea.Checked)
                    identity = "教师";
                //根据身份和用户名（id）验证用户是否存在
                String sql = "select * from securityInfo where u_object='"+identity +"' and u_id='"+u_id.Text.Trim()+"';";
                SqlDataReader sqlDr=dataOperate.getRow(sql);
                if (sqlDr.Read())
                {
                    //更新记录
                    sql = "update securityInfo set pwd='"+u_pwd.Text.Trim().GetHashCode()+"' where u_object='" + identity + "' and u_id='" + u_id.Text.Trim() + "';";
                    if (dataOperate.execSQL(sql))
                    {
                        lblTip.Text = "密码修改成功！";
                    }
                }
                else
                {
                    lblTip.Text = "修改失败，找不到该用户！";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}