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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1·采集用户输入
            string old_pwd = this.textBox1.Text.Trim();
            string new_pwd1 = this.textBox3.Text.Trim();
            string new_pwd2 = this.textBox2.Text.Trim();
            //2·校验两次新密码是否一致
            if (new_pwd1==new_pwd2)
            {
                //3·校验旧密码是否正确
                //使用当前的pwd和PWD.id作为条件进行匹配
                if (CheckOldPwd(old_pwd,PWD.Id))
                {
                    if (UpdatePwd(new_pwd2, PWD.Id))
                    {
                        MessageBox.Show("修改成功！");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
                else
                {
                    MessageBox.Show("用户输入密码有误!");
                }
                //4·修改密码


            }
            else
            {
                MessageBox.Show("两次新密码不一致！");
            }
        }

        private bool UpdatePwd(string new_pwd2, int id)
        {
            string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;Persist Security Info=True;User ID=sa;PassWord=3.14159";
            using (SqlConnection sqlConnection = new SqlConnection(connStr))
            {
                string sql = string.Format("update [user] set pwd='{0}'where id={1}", new_pwd2, id );
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlConnection.Open();
                    int r = Convert.ToInt32(sqlCommand.ExecuteNonQuery());
                    //if (r>0)
                    //{
                    //    return true;

                    //}
                    //else
                    //{
                    //    return false;
                    //}
                    return r>0 ;
                }
            }
        }

        private bool CheckOldPwd(string old_pwd, int id)
        {
            //string sql = string.Format("select count(*) from [user] where id={0} and pwd='{1}'", id, old_pwd);
            //string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" + "Persist Security Info=True;User ID=sa;Password=3.14159";
            string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;Persist Security Info=True;User ID=sa;PassWord=3.14159";
            using (SqlConnection sqlConnection=new SqlConnection(connStr))
            {
                string sql = string.Format("select count(*) from [user] where id={0} and pwd='{1}'", id, old_pwd);
                using (SqlCommand sqlCommand=new SqlCommand(sql,sqlConnection))
                {
                    sqlConnection.Open();
                    int r = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    //if (r>0)
                    //{
                    //    return true;

                    //}
                    //else
                    //{
                    //    return false;
                    //}
                    return r > 0;
                }
            }
        }
    }
}
