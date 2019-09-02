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

/// <summary>
/// dataOperate 的摘要说明
/// </summary>
public class dataOperate
{
    
    public dataOperate()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    
    /// <summary>
    /// 执行数据库添加、删除、更新等操作
    /// </summary>
    /// <param name="sql">需要执行的sql语句</param>
    /// <returns>返回一个布尔值，表示是否操作成功</returns>
    public static bool execSQL(string sql)
    {
        //创建数据库连接
        SqlConnection con = createCon();
        //打开数据库连接
        con.Open();
        //创建SqlCommand对象
        SqlCommand com = new SqlCommand(sql, con);
        try
        {
            //执行SQL语句
            com.ExecuteNonQuery();

        }
        catch (Exception e)
        {      
            //返回布尔值False
            return false;
        }
        finally
        {
            //关闭数据库连接
            con.Close();
        }
        //返回布尔值True
        return true;
    }
    /// <summary>
    /// 执行事务操作
    /// </summary>
    /// <param name="sql">字符串数组用来存储需要执行的sql语句</param>
    /// <returns>返回一个布尔值，表示是否操作成功</returns>
    public static bool execTransaction(string[] sql)
    {
        //创建数据库连接
        SqlConnection con = createCon();
        //创建SqlTransaction对象
        SqlTransaction sTransaction=null;
        try
        {
            //打开数据库连接
            con.Open();
            //创建SqlCommand对象
            SqlCommand com = con.CreateCommand();
            //设置开始事务
            sTransaction = con.BeginTransaction();
            //设置需要执行事务
            com.Transaction = sTransaction;
            foreach (string sqlT in sql)
            {
                //设置SQL语句
                com.CommandText = sqlT;
                //判断是否执行成功
                if (com.ExecuteNonQuery() <= 0)
                {
                    //设置事务回滚
                    sTransaction.Rollback();
                    //返回布尔值False
                    return false;
                }
            }
            //提交事务
            sTransaction.Commit();
            //返回布尔值True
            return true;
        }
        catch (Exception ex)
        {
            //设置事务回滚
            sTransaction.Rollback();
            //返回布尔值False
            return false;
        }
        finally
        {
            //关闭数据库连接
            con.Close();
        }
    }


    /// <summary>
    /// 查询数据是否存在
    /// </summary>
    /// <param name="sql">用来执行查询的SQL语句</param>
    /// <returns>返回一个整型变量，大于0表示存在</returns>
    public static int seleSQL(string sql)
    {
        //创建数据库连接
        SqlConnection con = createCon();
        //打开数据库连接
        con.Open();
        //创建SqlCommand对象
        SqlCommand com = new SqlCommand(sql, con);
        try
        {
            //返回ExecuteScalar方法返回的值
            return Convert.ToInt32(com.ExecuteScalar());      
        }
        catch (Exception e)
        {
            
            //返回整型值0
            return 0;
        }
        finally
        {
            //关闭数据库连接
            con.Close();
        }
    }
    /// <summary>
    /// 该方法用来执行用户登录操作，使用参数传递。
    /// </summary>
    /// <param name="sql">需要执行的sql语句</param>
    /// <param name="name">用户登录名</param>
    /// <param name="pass">用户登录密码</param>
    /// <returns>返回一个布尔值，表示是否登录成功</returns>
    public static bool entrySql(string sql, string name, string pass)
    {
        //创建数据库连接
        SqlConnection con = createCon();
        //打开数据库连接
        con.Open();
        //创建SqlCommand对象
        SqlCommand com = new SqlCommand(sql, con);
        //设置参数的类型
        com.Parameters.Add(new SqlParameter("name", SqlDbType.VarChar, 50));
        //设置参数的值
        com.Parameters["name"].Value = name;
        //设置参数的类型
        com.Parameters.Add(new SqlParameter("pass", SqlDbType.VarChar, 50));
        //设置参数的值
        com.Parameters["pass"].Value = pass;
        //判断是否登录成功并返回布尔值
        if (Convert.ToInt32(com.ExecuteScalar()) > 0)
        { 
            con.Close();
            return true;
           

        }
        else
        { 
            con.Close();
            return false;
           
        }

    }

    /// <summary>
    /// 用来查询记录，以DataSet对象形式返回
    /// </summary>
    /// <param name="sql">用来查询的sql语句</param>
    /// <returns>返回一个DataSet对象</returns>
    public static DataSet getDataset(string sql)
    {
        //创建数据库连接
        SqlConnection con = createCon();
        //打开数据库连接
        con.Open();
        //创建DataSet对象
        DataSet ds = new DataSet(); 
        //创建DataAdapter对象
        SqlDataAdapter sda = new SqlDataAdapter(sql, con);
        //填充DataSet数据集        
        sda.Fill(ds);
        //返回DataSet对象
        return ds;
    }
   /// <summary>
   /// 用来查询记录，以SqlDataReader对象形式返回
   /// </summary>
   /// <param name="sql">用来查询的sql语句</param>
   /// <returns>返回一个SqlDataReader对象</returns>
    public static SqlDataReader getRow(string sql)
    {
        //创建数据库连接
        SqlConnection con = createCon();
        //打开数据库连接
        con.Open();
        //创建SqlCommand对象
        SqlCommand com = new SqlCommand(sql, con);
        //返回ExecuteReader方法返回的DataReader对象
        return com.ExecuteReader();
    }

    /// <summary>
    /// 用来判断是否拥有权限菜单下的某一权限
    /// </summary>
    /// <param name="str">以逗号相隔的0或1，表示是否拥有权限</param>
    /// <returns>返回一个布尔值，True表示拥有权限菜单</returns>
    public static bool isAdm(string str)
    {
        //将字符串以“,”分隔填充到数组中
        string[] strAdm = str.Split(',');
        //遍历数组判断是否拥有“1”
        foreach (string admValue in strAdm)
        {
            if (admValue == "1")
            {
                return true;
                break;
            }
        }
        return false;
    }
   
    public static SqlConnection createCon()
    {
       SqlConnection con = new SqlConnection("server=(local);database=db_news;uid=sa;pwd=123456;");
        return con;
    }



}
