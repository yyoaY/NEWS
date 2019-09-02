using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NEWS
{
    public partial class Register : System.Web.UI.Page
    {
        //身份
        String identity;
        //编号
        String teaId;
        //学号
        String stuId;
        //姓名
        String uName;
        //密码
        String uPwd;
        //学院
        String uInstitute;
        //班级
        String uClass;
        //出生日期
        DateTime birth;
        //个性签名
        String mydescription;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitInstitution();
                InitClass();
                InitBirth();
            }

            HideAll();

            //显示身份模块
            p_identity.Visible = true;
            btn_rb.Visible = true;
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

        private void InitClass()//班级
        {
            ddlClass.Items.Add("15信管1");
            ddlClass.Items.Add("15信管2");
            ddlClass.Items.Add("15数技1");
            ddlClass.Items.Add("15数技2");
            ddlClass.Items.Add("15电信1");
            ddlClass.Items.Add("15电信2");
        }


        private void InitInstitution()//学院
        {
            ddlInstitute.Items.Add("新媒体学院");
            ddlInstitute.Items.Add("电子信息学院");
        }


        protected void btn_rb_Click(object sender, EventArgs e)
        {
            //隐藏所有模块
            HideAll();

            //显示下一模块
            p_namePwd.Visible = true;
            btn_impInfo.Visible = true;
            if (rb_stu.Checked)//身份为 学生
            {
                //显示学生重要信息模块
                p_stuId.Visible = true;
                p_stuClassInfo.Visible = true;

            }
            if (rb_tea.Checked)//身份为 教师
            {
                //显示教师重要信息模块
                p_teaId.Visible = true;
                p_teaInstitutionInfo.Visible = true;
            }

        }

        private void HideAll()//隐藏所有控件
        {
            p_identity.Visible = false;
            btn_rb.Visible = false;
            p_teaId.Visible = false;
            p_stuId.Visible = false;
            p_namePwd.Visible = false;
            p_stuClassInfo.Visible = false;
            btn_impInfo.Visible = false;
            p_others.Visible = false;
            btn_info.Visible = false;
            btn_submit.Visible = false;
            p_teaInstitutionInfo.Visible = false;
            btn_modify.Visible = false;
        }

        protected void btn_impInfo_Click(object sender, EventArgs e)
        {
            //隐藏所有
            HideAll();

            //显示下一模块
            p_others.Visible = true;
            btn_info.Visible = true;
        }

        protected void btn_info_Click(object sender, EventArgs e)
        {
            HideAll();

            //获得页面数据
            getCurrentPageData();

            //显示提交信息
            div_info.InnerHtml+="<p>身份：" + identity + "<br>姓名：" + uName ;
            if (rb_tea.Checked)
                div_info.InnerHtml += "<br>编号：" + teaId;
            if (rb_stu.Checked)
                div_info.InnerHtml += "<br>学号：" + stuId;
            div_info.InnerHtml += "<br>密码：" + uPwd;
            if (rb_tea.Checked)
                div_info.InnerHtml += "<br>学院：" + uInstitute;
            if (rb_stu.Checked)
                div_info.InnerHtml += "<br>班级：" + uClass;
            div_info.InnerHtml += "<br>出生日期：" + birth + "<br>个性签名：" + mydescription + "</p>";
            div_info.Visible = true;
            
            //显示修改/提交按钮
            btn_submit.Visible = true;
            btn_modify.Visible = true;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            //保存注册信息session -》 为登陆界面的自填充

            //获得页面数据
            getCurrentPageData();

            //录入数据库
            String sql = "";

            //信息安全表插入一条记录
            if (rb_stu.Checked)
                sql = "insert into SecurityInfo(u_object,u_id,pwd) values('" + identity + "','" + stuId + "','" + uPwd.GetHashCode() + "');";
            if (rb_tea.Checked)
                sql = "insert into SecurityInfo(u_object,u_id,pwd) values('" + identity + "','" + teaId + "','" + uPwd.GetHashCode() + "');";
            dataOperate.execSQL(sql);
            //Response.Write("信息安全表:添加成功！<br>");

            if (rb_stu.Checked)//学生
            {
                //学生表插入一条记录
                sql = "insert into stu(s_id,s_name,class,birth,mydescription) values('" + stuId + "','" + uName + "','" + uClass + "','" + birth + "','" + mydescription + "');";
                dataOperate.execSQL(sql);
                //Response.Write("学生表:添加成功！<br>");

            }
            else if (rb_tea.Checked)//教师
            {
                //教师表插入一条记录
                sql = "insert into tea(t_id,t_name,institution,birth,mydescription) values('" + teaId + "','" + uName + "','" + uInstitute + "','" + birth + "','" + mydescription + "');";
                dataOperate.execSQL(sql);
                //Response.Write("教师表:添加成功！<br>");

            }

            //跳转页面-》登陆界面
            Response.Redirect("Login.aspx");
        }

        private void getCurrentPageData()
        {
            //身份
            identity = "";
            if (rb_stu.Checked) identity = "学生";
            if (rb_tea.Checked) identity = "教师";
            //编号
            teaId = txt_teaId.Text.Trim();
            //学号
            stuId = txt_stuId.Text.Trim();
            //姓名
            uName = u_name.Text.Trim();
            //密码
            uPwd = u_pwd.Text.Trim();
            //学院
            uInstitute = ddlInstitute.Text.Trim();
            //班级
            uClass = ddlClass.Text.Trim();
            //出生日期
            int year = Convert.ToInt32(ddlYear.Text.Trim());
            int month = Convert.ToInt32(ddlMonth.Text.Trim());
            int day = Convert.ToInt32(ddlDay.Text.Trim());
            birth = new DateTime(year, month, day);
            //个性签名
            mydescription = txt_description.Text;
        }

        protected void btn_modify_Click(object sender, EventArgs e)
        {
            div_info.InnerHtml = "";
            div_info.Visible = false;
            Page_Load(sender, e);
        }
    }
}