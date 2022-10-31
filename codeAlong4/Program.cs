using Npgsql;

var connectionString = "host=localhost;db=northwind;uid=postgres;pwd=paranormalA1";

using var conn = new NpgsqlConnection(connectionString);
conn.Open();

using var cmd = new NpgsqlCommand();
cmd.CommandText = "select * from categories";
cmd.Connection = conn;

var rdr = cmd.ExecuteReader();

while (rdr.Read())
{
    Console.WriteLine($"Id={rdr.GetInt32(0)}, Name={rdr.GetString(1)}");
}