using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NEWS
{
    public partial class Hello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["u_id"] != null)//判断是否登录
            {
                bindBookType();
            }
            else
            {
                Response.Redirect("Login.aspx");//返回到登录页面
            }

            //从数据库获得姓名/个性签名
            String sql = "select s_name,mydescription from stu where s_id='" + Session["u_id"] + "';";
            SqlDataReader sqlDr = dataOperate.getRow(sql);
            if (sqlDr.Read())
            {
                sname.Text = sqlDr.GetValue(0).ToString();
                mydescription.Text = sqlDr.GetValue(1).ToString();
            }
        }

        protected void gvMyNews_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //执行循环，保证每条数据都可以更新
            for (int i = -1; i < gvMyNews.Rows.Count; i++)
            {
                //首先判断是否是数据行
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //当鼠标停留时更改背景色
                    e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='pink'");
                    //当鼠标移开时还原背景色
                    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                }
            }
        }

        protected void gvMyNews_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMyNews.EditIndex = e.NewEditIndex;
            bindBookType();

        }

        //自定义方法绑定我的消息
        public void bindBookType()
        {
            string sql = "select ni_id,n_time,publishedBy,n_title,n_content,n_state from newsInfo where receiver ='" + Session["u_id"].ToString() + "'";
            gvMyNews.DataSource = dataOperate.getDataset(sql);
            gvMyNews.DataKeyNames = new string[] { "ni_id" };//主键
            gvMyNews.DataBind();
        }

        //更新
        protected void gvMyNews_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool a = false;
            string n_state = ((TextBox)(gvMyNews.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim();
            if (n_state == "未读")
            {
                if (e.RowIndex >= gvMyNews.Rows.Count)
                {
                    lbl_tip.Text = "索引越界-" + e.RowIndex ;
                }
                else
                {
                    string sqlstr = "update newsInfo set n_state='已读' where ni_id='"
                                        + gvMyNews.DataKeys[e.RowIndex].Value.ToString() + "'";
                    a = dataOperate.execSQL(sqlstr);

                    gvMyNews.EditIndex = -1;

                    if (a)
                        lbl_tip.Text = "更改成功！";

                    else
                        lbl_tip.Text = "更改失败！";
                }

            }
            else
            {
                lbl_tip.Text = "更改失败，状态只能从“未读”修改为“已读”！！";
            }
            bindBookType();
        }

        //取消
        protected void gvMyNews_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMyNews.EditIndex = -1;
            bindBookType();
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

            if (dataOperate.execSQL(sqlstr)){
                lbl_tip.Text = "操作完成！";
                bindBookType();
            }
            else
                lbl_tip.Text = "操作失败！";
        }
    }
}