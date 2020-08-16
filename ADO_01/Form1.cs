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

namespace ADO_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData() 
        {
            /*1、List对象与Model对象之间通过反射
             * 建立联系，所以List只认识Model
             * 中的属性，不认识字段。
             */
            //List<Model>集合读取数据(model对象  ) 
            List<Model> list = new List<Model>();
            string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" +
                   "Persist Security Info=True;User ID=sa;Password=3.14159";
            using (SqlConnection sqlConnection=new SqlConnection(connStr))
            {
                string sql = "select * from news";
                using (SqlCommand sqlCommand=new SqlCommand(sql,sqlConnection))
                {
                    sqlConnection.Open();
                    using (SqlDataReader sqlDataReader=sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                Model model = new Model();
                                model.Id = sqlDataReader.GetInt32(0);
                                model.Title = sqlDataReader.GetString(1);
                                model.Content = sqlDataReader.GetString(2);//有null时需要判断
                                model.CreateTime = sqlDataReader.GetDateTime(3);
                                model.CaId = sqlDataReader.GetInt32(4);
                                list.Add(model);//添加model到list中
                            }
                        }
                    }
                }
            }
            //数据绑定时，只认“属性”，不显示“字段”；编写Model类时，要把需要的数据添加为属性
            this.dataGridView1.DataSource = list;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string title = addTitle.Text.Trim();
            string content = addContent.Text.Trim();
            int caId = Convert.ToInt32(addCaId.SelectedItem);
            string createTime = DateTime.Now.ToString().Trim();
            string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" +
                   "Persist Security Info=True;User ID=sa;Password=3.14159";
            using (SqlConnection con = new SqlConnection(connStr))
            {
                //con.Open();
                //1·编写SQL语句
                string sql = "insert into news values('" + title + "','" + content + "','" + createTime + "'," + caId + ")";
                //string sql = "insert into news values('华电','真好哦',(getdate())," + caId + ")";
                //2·创建执行对象SqlCommand
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //3·开始执行sql语句,这时打开连接con最节省资源
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    if (r>0)
                    {
                        this.Text = "添加成功!";
                        LoadData();
                    }
                    else
                    {
                        this.Text = "添加失败!";
                    }
                    //insert\delete\update返回受影响的行数,其他命令返回-1
                    //cmd.ExecuteScalar();//返回一行一列单个结果
                    //cmd.ExecuteReader();//查询多行多列结果
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 行焦点事件 ：Dgv中选中行的点击事件，也可用鼠标单击事件来实现。
        /// </summary>
        /// <param name="sender">Dgv控件</param>
        /// <param name="e">选中行对象</param>
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //获取选中行对象
            DataGridViewRow dataGridViewRow = this.dataGridView1.Rows[e.RowIndex];
            //获取当前行绑定的Model对象
            //as：当 需转换类型 需要转换成 目标引用类型 或 目标引用类型的派生 时，可以用as来进行安全高效的转换。如需转换值类型用is
            Model model = dataGridViewRow.DataBoundItem as Model;
            if (model!=null)
            {
                this.title.Text = model.Title.ToString();
                this.content.Text = model.Content.ToString();
                this.caId.Text = model.CaId.ToString();
                this.label10.Text = model.Id.ToString();
                this.label12.Text = model.CreateTime.ToString("yyyy-MM-dd");
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            //采集用户输入
            Model model = new Model();
            model.Id = Convert.ToInt32(this.label10.Text);
            model.CreateTime = Convert.ToDateTime(this.label12.Text);
            model.Title = this.title.Text;
            model.Content = this.content.Text;
            model.CaId = Convert.ToInt32(this.caId.Text);
            string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" +
                  "Persist Security Info=True;User ID=sa;Password=3.14159";
            using (SqlConnection con = new SqlConnection(connStr))
            {
                //con.Open();
                //1·编写SQL语句
                string sql = string.Format("update news set title='{0}',content='{1}',caID={2} where id={3}",model.Title,model.Content,model.CaId,model.Id);
                //2·创建执行对象SqlCommand
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //3·开始执行sql语句,这时打开连接con最节省资源
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        this.Text = string.Format("修改了{0}行!",r );
                        LoadData();
                    }
                    else
                    {
                        this.Text = "修改失败!";
                    }
                    //insert\delete\update返回受影响的行数,其他命令返回-1
                    //cmd.ExecuteScalar();//返回一行一列单个结果
                    //cmd.ExecuteReader();//查询多行多列结果
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要删除吗?","删除提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (result==System.Windows.Forms.DialogResult.OK)
            {
                string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" +
     "Persist Security Info=True;User ID=sa;Password=3.14159";
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    //con.Open();
                    //1·编写SQL语句
                    string sql = string.Format("delete from news where id={0}", Convert.ToInt32(this.label10.Text));
                    //2·创建执行对象SqlCommand
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        //3·开始执行sql语句,这时打开连接con最节省资源
                        con.Open();
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0)
                        {
                            this.Text = string.Format("删除成功！", r);
                            LoadData();
                        }
                        else
                        {
                            this.Text = "删除失败 !";
                        }
                        //insert\delete\update返回受影响的行数,其他命令返回-1
                        //cmd.ExecuteScalar();//返回一行一列单个结果
                        //cmd.ExecuteReader();//查询多行多列结果
                    }
                }
            }

        }
    }
}
