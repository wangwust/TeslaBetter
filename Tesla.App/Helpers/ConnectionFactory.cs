using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Tesla.App
{
    /// <summary>
    /// 数据库连接工厂
    /// </summary>
    public static class ConnectionFactory
    {
        /// <summary>
        /// Mysql数据库连接字符串
        /// </summary>
        private static string MysqlConnectionString => ConfigurationManager.ConnectionStrings["MysqlConnectionString"].ConnectionString;

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="connStr">数据库连接字符串</param>
        /// <returns></returns>
        public static IDbConnection GetInstance()
        {
            IDbConnection conn = new MySqlConnection(MysqlConnectionString); 
            conn.Open();
            return conn;
        }
    }
}
