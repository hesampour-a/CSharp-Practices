namespace BookStore;

public class BookStore(string name)
{
    public string Name { get; set; } = name;
    public string Address { get; set; } = String.Empty;
    public bool HasCafe { get; set; }
    public bool HasCozyPlaceToRead { get; set; }
    public bool HasStationery { get; set; }

    public void SellBook(string bookName)
    {
        Console.WriteLine($"Book {bookName} sold");
    }
    public void Consult(string customerName)
    {
        Console.WriteLine($"Wellcome to {Name} Book Store {customerName}");
    }

    public void QueuingForReadingEvent(string customerName, string readingEvent)
    {
        Console.WriteLine($"Dear {customerName} you have a turn in {readingEvent}");
    }

}
