using MySql.Data.MySqlClient;
using System.Data;

namespace databaskonstruktion.Models
{
    public class SpannModel
    {
        private IConfiguration _configuration;
        private string _connectionString;

        public SpannModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionString"];
        }

        public void InsertSpann(string name, int capacity)
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            string insertString = "INSERT INTO Spann VALUES(@NAME,@CAPACITY);";
            MySqlCommand sqlCmd = new MySqlCommand(insertString, dbcon);
            sqlCmd.Parameters.AddWithValue("@NAME", name);
            sqlCmd.Parameters.AddWithValue("@CAPACITY", capacity);
            int rows = sqlCmd.ExecuteNonQuery();
            dbcon.Close();
        }

        public DataTable GetAllSpann()
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Spann;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable spannTable = ds.Tables["result"];
            dbcon.Close();

            return spannTable;
        }

        public void DeleteSpann(string name)
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            string deleteString = "DELETE FROM Spann where Namn=@NAME;";
            MySqlCommand sqlCmd = new MySqlCommand(deleteString, dbcon);
            sqlCmd.Parameters.AddWithValue("@NAME", name);
            int rows = sqlCmd.ExecuteNonQuery();
            dbcon.Close();
        }
    }
}
