using Microsoft.Data.Sqlite;

public class Program
{
    public static void Main(string[] args)
    {
        var item = new Item() { Id = 1, Data = 1 };
        DoSomeStuffWithDB();
        Console.WriteLine($"Hello World!\n{item.Id}) - {item.Data}");
    }

    public static void DoSomeStuffWithDB()
    {
        using var conn = new SqliteConnection($"Data Source=items2.db; Foreign Keys=true; Mode=ReadOnly");
        conn.Open();
        string commandText = @"SELECT * FROM Items;";

        var command = new SqliteCommand(commandText, conn);
        using var reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                var data = reader.GetInt32(1);
                Console.WriteLine($"{id}) - {data}");
            }
        }
    }
}