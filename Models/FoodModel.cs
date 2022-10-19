using MySql.Data.MySqlClient;
using System.Data;

namespace databaskonstruktion.Models
{
    public class FoodModel
    {
        private IConfiguration _configuration;
        private string _connectionString;

        public FoodModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionString"];
        }

        public DataTable GetAllFood()
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Mat;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable foodTable = ds.Tables["result"];
            dbcon.Close();

            return foodTable;
        }

        public DataTable SearchFood(int magic)
        {
            MySqlConnection dbcon = new MySqlConnection(_connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Mat where Maginivå=@MAGIC;", dbcon);
            adapter.SelectCommand.Parameters.AddWithValue("@MAGIC", magic);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable foodTable = ds.Tables["result"];
            dbcon.Close();

            return foodTable;
        }
    }
}
