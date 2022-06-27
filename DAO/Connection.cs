using System.Data.SqlClient;

namespace WinFormsAsync.DAO
{
    public class Connection : IDisposable
    {

        private const string ConnectionString = @"Suas credenciais";
        private SqlConnection conn;


        public Connection()
        {
            Init();
        }

        private void Init()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConnectionString;
            conn.Open();
        }

        public SqlConnection GetConnection()
        {
            return conn;
        }

        public void CloseConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Dispose()
        {
            CloseConnection();
        }

    }
}
