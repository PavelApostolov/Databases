using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace SQLDemo
{
    class Program
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection(
                "Server = ./SQLEXPRESS;Database=TelerikAcademy;Integtated Security=true");

            connection.Open();
            Console.WriteLine("Connection opened");

            using (connection)
            {
                SqlCommand command = new SqlCommand("select top 10 * from Employees", connection);
                //var count = (int)command.ExecuteScalar();
                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    int count = 0;
                    while (reader.Read())
                    {
                        var id = reader[0];
                        var firstName = reader[1]; //reader["FirstName"];
                        Console.WriteLine("ID: {0}, firstname: {1}", id, firstName);
                        

                        for (int i = 0; i < reader.VisibleFieldCount; i++)
                        {
                            Console.WriteLine("- {0}", reader[i]);
                        }
                        count++;
                    }
                    Console.WriteLine("Number of employees {0}", count);
                }

                SqlCommand comm = new SqlCommand("insert into Townds(Name) values(@townName)", connection);
                comm.Parameters.AddWithValue("@townName", "Gabrovo");
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Rows Affected {0}", rowsAffected);

                comm.CommandText = "select @@Identity";
                var id = comm.ExecuteScalar();
                Console.WriteLine(id);

            }
            Console.WriteLine("Connection closed");
        }
    }
}
