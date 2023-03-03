using AzureSQLApplication.Models;
using System.Data.SqlClient;

namespace AzureSQLApplication.Services
{
    public class ProductService
    {
        private static string db_source = "webappserver2011.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "Amigo@2011";
        private static string db_database = "webappdb";

        private SqlConnection GetConnection()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = db_source;
            builder.UserID = db_user;
            builder.Password = db_password;
            builder.InitialCatalog = db_database;
            return new SqlConnection(builder.ConnectionString);
        }

        public List<Products> GetProducts()
        {
            SqlConnection sqlConnection = GetConnection();
            List<Products> products_list = new List<Products>();
            string sqlQuery = "SELECT ProductID,ProductName,Quantity FROM Products";
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Products products = new Products()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    products_list.Add(products);
                }
            }
            sqlConnection.Close();
            return products_list;
        }
    }
}
