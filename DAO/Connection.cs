using System.Data.SqlClient;

namespace WinFormsAsync.DAO
{
    public class Connection : IDisposable
    {

        private const string ConnectionString = @"Server=SRV-SIEMPRE-SQL\BASE_13;Database=STMBASE_status;User Id=sa;Password=sucesso;";
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
