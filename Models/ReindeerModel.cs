using MySql.Data.MySqlClient;
using System.Data;

namespace databaskonstruktion.Models
{
    public class ReindeerModel
    {
        private IConfiguration _configuration;
        private string _connectionString;

        public ReindeerModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionString"];
        }

        public DataTable GetAllReindeers()
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Ren;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable reindeerTable = ds.Tables["result"];
            dbcon.Close();

            return reindeerTable;
        }
    }
}
