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

namespace ADO_05Dataset与DataTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" + "Persist Security Info=True;User ID=sa;Password=3.14159";
            string sql = "select * from news";
            //DataTable dt = new DataTable();
            //using (SqlDataAdapter adapter=new SqlDataAdapter(sql,connStr))
            //{
            //    adapter.Fill(dt);
            //}

            this.dataGridView1.DataSource=SqlHelper.ExcuteDataTable(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1·创建一个DataSet（一个内存中的集合类型的数据库）
            DataSet ds = new DataSet("School");
            //2·创建一张表
            DataTable dt = new DataTable("Student");
            //2.1·向列中添加一些列

            //增加ID列
            DataColumn dcAutoId = new DataColumn("AutoId", typeof(int));

            //设置列自动编号
            dcAutoId.AutoIncrement = true;
            dcAutoId.AutoIncrementSeed = 1;
            dcAutoId.AutoIncrementStep = 1;

            dt.Columns.Add(dcAutoId);

            //增加姓名列
            DataColumn dcName = dt.Columns.Add("Name", typeof(string));
            //设置列不许为空
            dcName.AllowDBNull = false;

            //增加年龄列
            dt.Columns.Add("Age", typeof(int));

            //====================向表中增加数据=================================

            //创建一个行对象
            DataRow dr1 = dt.NewRow();//根据表结构创建行对象
            dr1["Name"] = "张慧鑫";
            dr1["Age"] = 20;

            DataRow dr2 = dt.NewRow();
            dr2["Name"] = "毛暑惠";
            dr2["Age"] = 19;

            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);


            //3·dt加到ds中
            ds.Tables.Add(dt);

            Console.WriteLine("-----------遍历表中数据------------");
            //1·遍历DataSet中的每张表
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                //输出表名
                Console.WriteLine("表名:{0}", ds.Tables[i].TableName);
                //遍历表中每一行
                for (int r = 0; r < ds.Tables[i].Rows.Count; r++)
                {
                    //获取每一行
                    DataRow currentRow = ds.Tables[i].Rows[r];
                    for (int j = 0; j < ds.Tables[i].Columns.Count; j++)
                    {
                        Console.Write("\t|" + currentRow[j] + "\t|");
                    }
                    Console.WriteLine();
                }
            }
            this.dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
