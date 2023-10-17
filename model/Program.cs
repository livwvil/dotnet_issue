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

        foreach (var item in items)
        {
            Console.WriteLine($"{item.Id}) - {item.Data}");
        }
    }
}