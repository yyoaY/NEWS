using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NEWS
{
    public partial class Login : System.Web.UI.Page
    {
        int errorNum;
        String username;
        String pwd;
        String identity="";
        String sqlStr = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                Session["identity"] = identity;
                errorNum = 0;
            }
            else
            {
                errorNum = Convert.ToInt16(Session["error"]);

            }

            //清空提示文本
            lblTip.Text = "";

            //验证码
            StringBuilder sb = new StringBuilder("ValidCode.aspx?code=");
            Random d = new Random();
            sb.Append((char)d.Next(48, 58));
            sb.Append((char)d.Next(48, 58));
            sb.Append((char)d.Next(48, 58));
            sb.Append((char)d.Next(48, 58));
            imgValidCode.ImageUrl = sb.ToString();
        }


        protected void btnLogin_Click(object sender, EventArgs e)//注册
        {
            //跳转到注册界面
            Response.Redirect("Register.aspx");
        }


        protected void btnResetPwd_Click(object sender, EventArgs e)//忘记密码
        {
            //记录id和身份
            Session["u_id"] = username;
            Session["identity"] = identity;
            //跳转到修改密码界面
            Response.Redirect("ResetPwdPage.aspx");
        }

        protected void btnSignIn_Click(object sender, EventArgs e)//登录
        {
            username = txtUsername.Text.Trim();//用户名
            pwd = txtPwd.Text.Trim();//密码
            string Code = txtValidCode.Text;//验证码
            //Response.Write("identity=" + Session["identity"]);
            //验证身份
            if (Session["identity"].ToString() == "学生" | Session["identity"].ToString() == "教师" | Session["identity"].ToString() == "管理员")
            {
                //如果验证码正确，继续
                if (Code == Session["Code"].ToString())
                {
                    //验证用户合法性
                    sqlStr = "select * from securityInfo where u_object='" + Session["identity"] + "' and u_id='" + username + "' and pwd='" + pwd.GetHashCode() + "'";

                    if (dataOperate.seleSQL(sqlStr)!=0)
                    {//有记录，登录成功
                        Session["u_id"] = username;
                        if(Session["identity"].ToString()=="学生")
                        {
                            //跳转到学生用户界面
                            Response.Redirect("studentPage.aspx");
                        }
                        else if (Session["identity"].ToString() == "教师")
                        {
                            //跳转到教师用户界面
                            Response.Redirect("teacherPage.aspx");
                        }
                        else if (Session["identity"].ToString() == "管理员")
                        {
                            if (Session["u_id"].ToString().Trim()=="admin")
                            {
                                //超级管理员
                                Response.Redirect("superAdminPage.aspx");
                            }
                            else
                            {
                                //跳转到管理员用户界面
                                Response.Redirect("adminPage.aspx");
                            }
                        }
                    }
                    else
                    {//无记录，登录失败
                        lblTip.Text = "登录失败！请输入正确的用户名与密码！";
                        fail();

                    }
                }
                else
                {
                    //验证码错误
                    lblTip.Text = "登录失败！验证码错误！";
                    fail();
                }
            }
            else
            {
                //未选择身份
                lblTip.Text = "登录失败！请选择您的身份！";
                fail();
            }
        }


        protected void fail()
        {
            ++errorNum;
            Session["error"] = errorNum;

            //限制登录次数 3次
            if (errorNum > 2)
            {
                //重置登录失败计数器
                errorNum = 0;

                //禁止输入10秒
                startTimer();//开始计时
                validateToSignIn(false);//登录控件不可用
            }
        }
        protected void startTimer()
        {
            LabelTime.Text = "10";
            TimerLableVisible(true);//显示提示及倒计时
            Timer1.Enabled = true;
        }

        private void validateToSignIn(Boolean p)
        {
            txtUsername.Enabled = p;//用户名文本框
            txtPwd.Enabled = p;//密码文本框
            txtValidCode.Enabled = p;//验证码文本框
            btnSignIn.Enabled = p;//登录按钮
            if (p)
            {
                btnSignIn.BackColor = Color.DodgerBlue;
            }
            else
            {
                btnSignIn.BackColor = Color.LightCoral;
            }
        }

        protected void TimerLableVisible(Boolean b)
        {//提示文本显示情况
            LabelTime.Visible = b;
            Labelt1.Visible = b;
            Labelt2.Visible = b;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            LabelTime.Text = (Convert.ToInt16(LabelTime.Text.Trim()) - 1).ToString();
            if (LabelTime.Text.Trim() == "-1")
            {
                validateToSignIn(true);
                Timer1.Enabled = false;
                TimerLableVisible(false);
            }
        }

        protected void btn_stu_Click(object sender, EventArgs e)
        {
            //“学生”颜色高亮
            btn_stu.BackColor = Color.DodgerBlue;
            btn_tea.BackColor = Color.LightGray;
            btn_admin.BackColor = Color.LightGray;

            Session["identity"] = "学生";
        }

        protected void btn_tea_Click(object sender, EventArgs e)
        {
            //“教师”颜色高亮
            btn_tea.BackColor = Color.DodgerBlue;
            btn_stu.BackColor = Color.LightGray;
            btn_admin.BackColor = Color.LightGray;

            Session["identity"] = "教师";
        }

        protected void btn_admin_Click(object sender, EventArgs e)
        {
            //“管理员”颜色高亮
            btn_admin.BackColor = Color.DodgerBlue;
            btn_stu.BackColor = Color.LightGray;
            btn_tea.BackColor = Color.LightGray;

            Session["identity"] = "管理员";
        }

    }
}