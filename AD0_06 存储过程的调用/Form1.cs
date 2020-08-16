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

namespace AD0_06_存储过程的调用
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int pageIndex = 1;//当前要查看的页码
        private int pageSize = 5;//每页的数据条数
        private int pageCount;//总页数

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;Persist Security info=true;User ID=sa;Password=3.14159";
            #region connection
            //using (SqlConnection sqlConnection = new SqlConnection(connStr))
            //{
            //    string sql = "usp_loadPage";
            //    using (SqlCommand command = new SqlCommand(sql, sqlConnection))
            //    {
            //        //告诉Command对象执行的是存储过程,SQL语句前面有exec的话这句可以不加
            //        command.CommandType = CommandType.StoredProcedure;

            //        //添加存储参数
            //        //@pageSize int= 5,--默认每页条数
            //        //@pageIndex int= 1,--需要查询的页数
            //        //@pageCount int output--可以查询的总页数
            //        SqlParameter[] pms = new SqlParameter[] {
            //            new SqlParameter("@pageSize",SqlDbType.Int){Value=pageSize},
            //            new SqlParameter("@pageIndex",SqlDbType.Int){Value=pageIndex},
            //            new SqlParameter("@pageCount",SqlDbType.Int){Direction=ParameterDirection.Output}
            //        };
            //        command.Parameters.AddRange(pms);
            //        //打开连接
            //        sqlConnection.Open();
            //    }
            //}
            #endregion
            #region Adapter
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter=new SqlDataAdapter("usp_loadPage",connStr))
            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlParameter[] pms = new SqlParameter[] {
                        new SqlParameter("@pageSize",SqlDbType.Int){Value=pageSize},
                        new SqlParameter("@pageIndex",SqlDbType.Int){Value=pageIndex},
                        new SqlParameter("@pageCount",SqlDbType.Int){Direction=ParameterDirection.Output}
                };
                adapter.SelectCommand.Parameters.AddRange(pms);
                adapter.Fill(dt);

                //数据绑定
                pageCount = Convert.ToInt32(pms[2].Value);
                label2.Text = pms[2].Value.ToString();
                label3.Text = "当前页：" + pageIndex.ToString();
                this.dataGridView1.DataSource = dt;
            }
            #endregion
            }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pageIndex>1)
            {
                pageIndex--;
                LoadData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pageIndex<pageCount)
            {
                pageIndex++;
                LoadData();
            }
        }
    }
}
