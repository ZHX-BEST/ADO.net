using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_01
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 连接数据库
            /*步骤：
             * 1·创建连接字符串
             * 2·创建连接对象
             * 3·打开连接
             * 4·关闭连接释放资源
             */


            ////1·创建连接字符串
            ////Data Source服务器与实例（没有实例就用默认实例）
            ////Initial Catalog初始连接数据库
            ////Persist Security Info=True ADO在数据库连接成功后是否保存密码信息
            //string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" +
            //    "Persist Security Info=True;User ID=sa;Password=3.14159";
            ////2·创建连接对象
            ////using结构默认调用dispose函数，结束后可以自动close同时释放对象资源 
            //using (SqlConnection con=new SqlConnection(connStr))
            //{
            //    //3·打开连接
            //    con.Open();
            //    Console.WriteLine("连接成功！");
            //    //4·关闭连接
            //    //con.Close();
            //}
            //Console.WriteLine("连接关闭，释放资源 ！");
            //Console.ReadKey();

            #endregion
            #region 插入一条数据
            //string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" +
            //       "Persist Security Info=True;User ID=sa;Password=3.14159";
            //using (SqlConnection con = new SqlConnection(connStr))
            //{
            //    //con.Open();
            //    //1·编写SQL语句
            //    string sql = "insert into news values('华电','真好哦',(getdate()),4)";
            //    //2·创建执行对象SqlCommand
            //    using (SqlCommand cmd=new SqlCommand(sql,con))
            //    {
            //        //3·开始执行sql语句,这时打开连接con最节省资源
            //        con.Open();
            //        int r=cmd.ExecuteNonQuery();//insert\delete\update返回受影响的行数,其他命令返回-1
            //        //cmd.ExecuteScalar();//返回一行一列单个结果
            //        //cmd.ExecuteReader();//查询多行多列结果
            //        Console.WriteLine("成功插入{0}行数据",r);
            //    }
            //}
            //Console.ReadKey();
            #endregion
            #region 删除一条数据
            //string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" +
            //       "Persist Security Info=True;User ID=sa;Password=3.14159";
            //using (SqlConnection con = new SqlConnection(connStr))
            //{
            //    //con.Open();
            //    //1·编写SQL语句
            //    string sql = "delete from news where id=131";
            //    //2·创建执行对象SqlCommand
            //    using (SqlCommand cmd = new SqlCommand(sql, con))
            //    {
            //        //3·开始执行sql语句,这时打开连接con最节省资源
            //        con.Open();
            //        int r = cmd.ExecuteNonQuery();//insert\delete\update返回受影响的行数,其他命令返回-1
            //        //cmd.ExecuteScalar();//返回一行一列单个结果
            //        //cmd.ExecuteReader();//查询多行多列结果
            //        Console.WriteLine("成功删除{0}行数据", r);
            //    }
            //}
            //Console.ReadKey();
            #endregion
            #region 更新一条数据
            //string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" +
            //       "Persist Security Info=True;User ID=sa;Password=3.14159";
            //using (SqlConnection con = new SqlConnection(connStr))
            //{
            //    //con.Open();
            //    //1·编写SQL语句
            //    string sql = "update news set createTime=(GETDATE())where id=128";
            //    //2·创建执行对象SqlCommand
            //    using (SqlCommand cmd = new SqlCommand(sql, con))
            //    {
            //        //3·开始执行sql语句,这时打开连接con最节省资源
            //        con.Open();
            //        int r = cmd.ExecuteNonQuery();//insert\delete\update返回受影响的行数,其他命令返回-1
            //        //cmd.ExecuteScalar();//返回一行一列单个结果
            //        //cmd.ExecuteReader();//查询多行多列结果
            //        Console.WriteLine("成功更新{0}行数据", r);
            //    }
            //}
            //Console.ReadKey();
            #endregion
            #region 查询记录数
            //string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" +
            //       "Persist Security Info=True;User ID=sa;Password=3.14159";
            //using (SqlConnection con = new SqlConnection(connStr))
            //{
            //    //con.Open();
            //    //1·编写SQL语句
            //    string sql = "select count(*) from news";
            //    //2·创建执行对象SqlCommand
            //    using (SqlCommand cmd = new SqlCommand(sql, con))
            //    {
            //        //3·开始执行sql语句,这时打开连接con最节省资源
            //        con.Open();
            //        //cmd.ExecuteNonQuery();//insert\delete\update返回受影响的行数,其他命令返回-1
            //        object r = Convert.ToInt32(cmd.ExecuteScalar());//返回一行一列单个对象结果(聚合函数返回值不可能是null)
            //        //cmd.ExecuteReader();//查询多行多列结果
            //        Console.WriteLine("表中有{0}行数据", r);
            //    }
            //}
            //Console.ReadKey();
            #endregion
            #region 查询表(返回结果集)
            //string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" +
            //       "Persist Security Info=True;User ID=sa;Password=3.14159";
            //using (SqlConnection con = new SqlConnection(connStr))
            //{
            //    //con.Open();
            //    //1·编写SQL语句
            //    string sql = "select * from news";
            //    //2·创建执行对象SqlCommand
            //    using (SqlCommand cmd = new SqlCommand(sql, con))
            //    {
            //        //3·开始执行sql语句,这时打开连接con最节省资源
            //        con.Open();
            //        //cmd.ExecuteNonQuery();//insert\delete\update返回受影响的行数,其他命令返回-1
            //        //cmd.ExecuteScalar();//返回一行一列单个对象结果(聚合函数返回值不可能是null)
            //        //cmd.ExecuteReader();//查询多行多列结果,返回一个SqlDatareader的对象
            //        using (SqlDataReader sqlDataReader = cmd.ExecuteReader()) //sqlDataReader 要求独占一个连接，且在读取时不能中断
            //        {
            //            if (sqlDataReader.HasRows)//判断结果集中有没有行
            //            {
            //                while (sqlDataReader.Read())//判断下一行中有没有数据来作为跳出循环的条件
            //                {
            //                    for (int i = 0; i < sqlDataReader.FieldCount; i++)//sqlDataReader.FieldCount获取列数
            //                    {
            //                        Console.Write(sqlDataReader[i]+"     ");//sqlDataReader[i]索引器也可以通过列名来获取数据，获取到的null是一个空字符串
            //                    }
            //                    Console.WriteLine();
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine("没有查询到任何数据！");
            //            }
            //        }
            //    }
            //}
            //Console.ReadKey();
            #endregion
            #region 查询表2
            string connStr = "Data Source=DESKTOP-UC5SPIS\\SQLEXPRESS;Initial Catalog=news;" +
                   "Persist Security Info=True;User ID=sa;Password=3.14159";
            using (SqlConnection con = new SqlConnection(connStr))
            {
                //con.Open();
                //1·编写SQL语句
                string sql = "select * from news";
                //2·创建执行对象SqlCommand
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //3·开始执行sql语句,这时打开连接con最节省资源
                    con.Open();
                    //cmd.ExecuteNonQuery();//insert\delete\update返回受影响的行数,其他命令返回-1
                    //cmd.ExecuteScalar();//返回一行一列单个对象结果(聚合函数返回值不可能是null)
                    //cmd.ExecuteReader();//查询多行多列结果,返回一个SqlDatareader的对象
                    using (SqlDataReader sqlDataReader = cmd.ExecuteReader()) //sqlDataReader 要求独占一个连接，且在读取时不能中断
                    {
                        if (sqlDataReader.HasRows)//判断结果集中有没有行
                        {
                            while (sqlDataReader.Read())//判断下一行中有没有数据来作为跳出循环的条件
                            {
                                //sqlDataReader.Get****()强类型获取数据，无需类型转换，无法处理null值,用IsDBnull判断
                                Console.Write(sqlDataReader.IsDBNull(0) ? "NULL" : sqlDataReader.GetValue(0) + "\t|\t");//加了\t|\t后隐式转换为字符串类型，否则需要显式转换
                                Console.Write(sqlDataReader.IsDBNull(1) ? "NULL" : sqlDataReader.GetValue(1) + "\t|\t");//加了\t|\t后隐式转换为字符串类型，否则需要显式转换
                                Console.Write(sqlDataReader.IsDBNull(2) ? "NULL" : sqlDataReader.GetValue(2) + "\t|\t");//加了\t|\t后隐式转换为字符串类型，否则需要显式转换
                                Console.Write(sqlDataReader.IsDBNull(3) ? "NULL" : sqlDataReader.GetValue(3) + "\t|\t");//加了\t|\t后隐式转换为字符串类型，否则需要显式转换
                                Console.Write(sqlDataReader.IsDBNull(4) ? "NULL" : sqlDataReader.GetValue(4) + "\t|\t");//加了\t|\t后隐式转换为字符串类型，否则需要显式转换
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("没有查询到任何数据！");
                        }
                    }
                }
            }
            Console.ReadKey();
            #endregion
        }
    }
}
