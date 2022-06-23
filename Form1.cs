using System.Data.SqlClient;
using WinFormsAsync.DAO;

namespace WinFormsAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            var rs = await GetRs();

            MessageBox.Show("Razão social: " + rs);

        }



        public async Task<string> GetRs()
        {

            object rs;

            using (var Connection = new Connection())
            {

                var cmd = new SqlCommand();
                cmd.Connection = Connection.GetConnection();
                cmd.CommandText = "SELECT TOP (1) razao_social FROM Empresas WHERE Cod_empresa = @id";
                cmd.Parameters.AddWithValue("@id", "001");

                rs = await cmd.ExecuteScalarAsync();

            }

            return rs.ToString();
        }





    }
}