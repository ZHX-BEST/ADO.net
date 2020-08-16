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

namespace ADO_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select count(*) from [user] where uid=@uid and pwd=@pwd";
            SqlParameter[] pms = new SqlParameter[] {
                new SqlParameter("@uid",SqlDbType.VarChar,18){ Value=this.textBox1.Text.Trim()},
                new SqlParameter("@pwd",SqlDbType.VarChar,8){ Value=this.textBox2.Text}
            };
            int r = Convert.ToInt32(SqlHelper.ExecutScalar(sql,pms));
            if (r>0)
            {
                MessageBox.Show("登陆成功！");
            }
            else
            {
                MessageBox.Show("登陆失败！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<User> list = new List<User>();
            string sql = "select * from [user]";
            using (SqlDataReader sqlData =SqlHelper.ExecuteReader(sql))
            {
                if (sqlData.HasRows)
                {
                    while (sqlData.Read())
                    {
                        User user = new User();
                        user.Id = sqlData.GetInt32(0);
                        user.Uid = sqlData.IsDBNull(1) ? null : sqlData.GetString(1);
                        user.Pwd = sqlData.IsDBNull(2) ? null : sqlData.GetString(2);
                        list.Add(user);
                    }
                }
            }
            MessageBox.Show(list.Count.ToString());
            
        }
    }
}
