using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ADO_05Dataset与DataTable
{
    public static class SqlHelper
    {
        //数据库连接字符串存储在配置文件中，好处：直接修改，无需编译,需要添加引用System.Configuration
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        /// <summary>
        /// 1·返回受影响的行数ExecuteNonQuery()--insert/delete/update
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pms">参数数组</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] pms)//用数组来表示可变参数
        {
            using (SqlConnection sqlConnection=new SqlConnection(connStr))
            {
                using (SqlCommand sqlCommand=new SqlCommand(sql,sqlConnection))
                {
                    if (pms != null) 
                    {
                        sqlCommand.Parameters.AddRange(pms);
                    }
                    sqlConnection.Open();
                    return sqlCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 2·返回一行一列ExecuteScalar()--查询返回单个值
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pms">参数数组</param>
        /// <returns></returns>
        public static object ExecutScalar(string sql, params SqlParameter[] pms)//用数组来表示可变参数
        {
            using (SqlConnection sqlConnection = new SqlConnection(connStr))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    if (pms != null)
                    {
                        sqlCommand.Parameters.AddRange(pms);
                    }
                    sqlConnection.Open();
                    return sqlCommand.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 3·返回多行多列ExecuteReader()--查询返回多个值
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pms">参数数组</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            using (SqlCommand sqlCommand=new SqlCommand(sql,sqlConnection))
            {
                if (pms!=null)
                {
                    sqlCommand.Parameters.AddRange(pms);
                }
                try
                {
                    sqlConnection.Open();
                    //System.Data.CommandBehavior.CloseConnection枚举参数，表示使用完SQLDataReader的时候，关闭reader的同时在SQLDataReader内部关闭所有有关的Connection
                    return sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    throw;
                }
            }
        }
        public static DataTable ExcuteDataTable(string sql, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter sqlDataAdapter=new SqlDataAdapter(sql,connStr))
            {
                if (pms!=null)
                {
                    sqlDataAdapter.SelectCommand.Parameters.AddRange(pms); 
                }
                sqlDataAdapter.Fill(dt);
            }
            return dt;
        }
    }
}
