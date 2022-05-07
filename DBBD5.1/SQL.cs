using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace DBBD51
{
    public static class SQL
    {
        public static IEnumerable<IEnumerable<string>> ReadSql(string sqlExpression)
        {
            string connectionString = @"Data Source=KOMPYTER-ALEKSE\SQLEXPRESS;Initial Catalog=InSy;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand(sqlExpression, connection);
            var reader = command.ExecuteReader();
            var table = new List<List<string>>();
            var row = new List<string>();
            int nRows = reader.FieldCount;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < nRows; i++)
                    {
                        row.Add(reader.GetValue(i).ToString());
                    }
                    table.Add(row);
                    row = new List<string>();
                }
            }
            reader.Close();
            connection.Close();
            return table;
        }

        public static int maxIndex(string command) => int.Parse(ReadSql(command).ToList()[0].ToList()[0]);

        //действия с таблицой - сохранение итд
        public static void InteractingSql(string sqlExpression)
        {
            string connectionString = @"Data Source=KOMPYTER-ALEKSE\SQLEXPRESS;Initial Catalog=InSy;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            int number = command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
