public class Program
{
    public static void Main(string[] args)
    {
        var item = new Item() { Id = 1, Data = 1 };

        Console.WriteLine($"Hello World!\n{item.Id}) - {item.Data}");
    }
}