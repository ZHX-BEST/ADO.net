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

namespace ADO_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //把所有的类别加载到comboxCa上
            LoadCategory();
        }

        private void LoadCategory()
        {
            string sql = "select id,name from category";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CaModel ca = new CaModel();
                        ca.Id = reader.GetInt32(0);
                        ca.Name = reader.GetString(1);
                        comboBoxCa.Items.Add(ca);
                    }
                }
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBoxCa.SelectedItem!=null)
            {
                CaModel ca = comboBoxCa.SelectedItem as CaModel;
                MessageBox.Show(ca.Id+"   "+ca.Name);
            }
        }

        //选择项g改变事件
        private void comboBoxCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取当前类别ID
            if (comboBoxCa.SelectedItem != null)
            {
                CaModel ca = comboBoxCa.SelectedItem as CaModel;
                int caId = ca.Id;
                //根据类别ID在数据库中查询
                string sql = "select id,title from news where caID=@caID";
                SqlParameter parameter = new SqlParameter("@caID", SqlDbType.Int) { Value = caId };
                List<NewsModel> list = new List<NewsModel>();
                using (SqlDataReader reader= SqlHelper.ExecuteReader(sql, parameter))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            NewsModel news = new NewsModel();
                            news.Id = reader.GetInt32(0);
                            news.Title = reader.IsDBNull(1) ? null : reader.GetString(1);
                            list.Add(news);
                        }
                    }
                }
                comboBoxNews.DisplayMember = "Title";
                comboBoxNews.ValueMember = "Id";
                comboBoxNews.DataSource = list;
            }
        }
    }
}
