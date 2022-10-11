using MySql.Data.MySqlClient;
using System.Data;

namespace databaskonstruktion.Models
{
    public class FoodModel
    {
        private IConfiguration _configuration;
        private string connectionString;

        public FoodModel(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration["ConnectionString"];
        }

        public DataTable GetAllFood()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM Mat;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable foodTable = ds.Tables["result"];
            dbcon.Close();

            return foodTable;
        }
    }
}
