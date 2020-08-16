using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denglu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button3.Visible = false;

        }

        /// <summary>
        /// 验证用户是否登陆成功
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //采集用户数据
            string uid = this.textBox1.Text.Trim();
            string pwd = this.textBox2.Text.Trim();
            #region SQL拼接（有SQL注入的风险）
            //连接数据库验证
            //string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" + "Persist Security Info=True;User ID=sa;Password=3.14159";
            //using (SqlConnection sqlConnection = new SqlConnection(connStr))
            //{
            //    string sql = string.Format("select count(*) from [user] where uid='{0}' and pwd='{1}'", uid, pwd);
            //    using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
            //    {
            //        sqlConnection.Open();
            //        int count = (int)sqlCommand.ExecuteScalar();
            //        if (count>0)
            //        {
            //            this.BackColor = Color.Green;
            //        }
            //        else
            //        {
            //            this.BackColor = Color.Red;
            //        }
            //    }
            //}
            #endregion
            #region 带参数的SQL语句(事实上是调用一个内置的数据库存储过程)
            string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" + "Persist Security Info=True;User ID=sa;Password=3.14159";
            using (SqlConnection sqlConnection = new SqlConnection(connStr))
            {
                //T-SQL带参数（变量）的SQL语句，参数（变量）以@开头
                string sql = "select count(*) from [user] where uid=@paramuid and pwd=@parampwd";
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    //使用带参数得到SQL语句时，如有变量出现，需要在command中对变量赋值

                    ////1、创建两个参数对象
                    //SqlParameter parameter1 = new SqlParameter("@paramuid", SqlDbType.VarChar, 18)
                    //{ Value = this.textBox1.Text.Trim() };
                    //SqlParameter parameter2 = new SqlParameter("@parampwd", SqlDbType.VarChar, 8)
                    //{ Value = this.textBox2.Text.Trim() };

                    ////将参数对象添加在sqlCommand中
                    //sqlCommand.Parameters.Add(parameter1);
                    //sqlCommand.Parameters.Add(parameter2);

                    ////2、创建参数对象数组
                    //SqlParameter[] pams = new SqlParameter[]
                    //{
                    //    new SqlParameter("@paramuid", SqlDbType.VarChar, 18){ Value = this.textBox1.Text.Trim() },
                    //     new SqlParameter("@parampwd", SqlDbType.VarChar, 8){ Value = this.textBox2.Text.Trim() }      
                    //};
                    ////添加参数数组
                    //sqlCommand.Parameters.AddRange(pams);
                    //3、直接添加参数
                    sqlCommand.Parameters.AddWithValue("@paramuid", this.textBox1.Text.Trim());
                    sqlCommand.Parameters.AddWithValue("@parampwd", this.textBox2.Text.Trim());


                    sqlConnection.Open();
                    int count = (int)sqlCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        this.BackColor = Color.Green;
                    }
                    else
                    {
                        this.BackColor = Color.Red;
                    }
                }
            }
            #endregion
        }
        /// <summary>
        /// 先验证用户名是否存在，再判断密码是否正确
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //采集用户数据
            string uid = this.textBox1.Text.Trim();
            string pwd = this.textBox2.Text.Trim();
            //连接数据库验证
            string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" + "Persist Security Info=True;User ID=sa;Password=3.14159";
            using (SqlConnection sqlConnection = new SqlConnection(connStr))
            {
                string sqlUid = string.Format("select *   from [user] where uid='{0}'", uid);
               
                using (SqlCommand sqlCommand = new SqlCommand(sqlUid, sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            if (sqlDataReader.Read())
                            {
                                string dbpwd = sqlDataReader.GetString(2);
                                if (pwd==dbpwd)
                                {
                                    this.Text = "登陆成功！";
                                    this.button3.Visible = true;
                                    PWD.Id = sqlDataReader.GetInt32(0);
                                }
                                else
                                {
                                    this.Text = "密码错误！";
                                }
                            }
                        }
                        else
                        {
                            this.Text = "无此用户！";
                        }
                    }
                    //if (count > 0)
                    //{
                    //    //存在该用户
                                                   
                    //}
                    //else
                    //{
                    //    this.Text = "无此用户！";
                    //}
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
