using Microsoft.Data.Sqlite;

public class Item
{
    public int Id { get; set; }
    public int Data { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        var items = new List<Item>()
        {
            new Item() { Id = 1, Data = 1 },
            new Item() { Id = 2, Data = 2 },
            new Item() { Id = 3, Data = 3 }
        };

        DoSomeStuffWithDB();

        foreach (var item in items)
        {
            Console.WriteLine($"{item.Id}) - {item.Data}");
        }
    }

    public static void DoSomeStuffWithDB()
    {
        using var conn = new SqliteConnection($"Data Source=items1.db; Foreign Keys=true; Mode=ReadOnly");
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