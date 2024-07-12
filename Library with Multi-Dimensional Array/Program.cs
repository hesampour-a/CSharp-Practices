// books[n,0] = Book Nmae
// books[n,1] = Book Author
// books[n,2] = Book Location
// books[n,3] = Book Count
// books[n,4] = Book IsAvailable



string[,] books = new string[1, 5];

books[0, 0] = "Name";
books[0, 1] = "Author";
books[0, 2] = "Location";
books[0, 3] = "Count";
books[0, 4] = "IsAvailable";

while (true)
{

    string operation = GetStringFromUser("Enter Operation (Add,Search,Remove,Show) :");
    switch (operation)
    {
        case "Add":
            books = AddNewBook(books);
            break;
        case "Search":
            SearchByName(books);
            break;
        case "Remove":
            int bookId = GetNumberFromUser("insert the number of book");
            books = RemoveBookById(bookId, books);
            break;
        case "Show":
            ShowAllBooks(books);
            break;
        default:
            break;
    }

}



string[,] AddNewBook(string[,] books)
{
    string[,] newBooks = new string[books.GetLength(0) + 1, books.GetLength(1)];
    newBooks = CopyArray(books, newBooks);

    for (int i = 0; i < books.GetLength(1); i++)
    {
        newBooks[newBooks.GetLength(0) - 1, i] = GetStringFromUser("insert new book " + books[0, i]);
    }

    return newBooks;
}


string[,] CopyArray(string[,] sourceArray, string[,] destinationArray)
{
    if (destinationArray.Length < sourceArray.Length)
    {
        Console.WriteLine("destination array is not large enough");
        return sourceArray;
    }
    for (int i = 0; i < sourceArray.GetLength(0); i++)
    {
        for (int j = 0; j < sourceArray.GetLength(1); j++)
        {
            destinationArray[i, j] = sourceArray[i, j];
        }
    }
    return destinationArray;
}

string GetStringFromUser(string message)
{
    bool trueText = false;
    string inputText = "";
    while (!trueText)
    {
        Console.WriteLine(message);
        inputText = Console.ReadLine();
        trueText = true;

        if (inputText == "")
        {
            Console.WriteLine("Enter a correct text");
            trueText = false;
        }
    }

    return inputText!;
}


void ShowAllBooks(string[,] books)
{
    if (books.Length <= 1)
    {
        Console.WriteLine("there is no book");
    }
    for (int i = 1; i < books.GetLength(0); i++)
    {
        Console.Write("Book # " + i + " : ");
        for (int j = 0; j < books.GetLength(1); j++)
        {
            Console.Write(books[0, j] + " : " + books[i, j] + "  *");
        }
        Console.WriteLine();

    }
    return;
}

void ShowBookById(int bookId, string[,] books)
{

    Console.Write("Book # " + bookId + " : ");
    for (int j = 0; j < books.GetLength(1); j++)
    {
        Console.Write(books[0, j] + " : " + books[bookId, j] + "  *");
    }
    Console.WriteLine();


}

void SearchByName(string[,] books)
{
    bool found = false;
    string name = GetStringFromUser("Insert name or a part of name :");
    for (int i = 0; i < books.GetLength(0); i++)
    {
        if (books[i, 0].Contains(name))
        {
            found = true;
            ShowBookById(i, books);
        }
    }
    if (!found)
    {
        Console.WriteLine("Book not found");
    }
}

string[,] RemoveBookById(int bookId, string[,] books)
{
    if (bookId > books.GetLength(0) - 1)
    {
        Console.WriteLine("index out of range");
        return books;
    }
    string[,] newBooks = new string[books.GetLength(0) - 1, books.GetLength(1)];
    int newId = 0;
    for (int i = 0; i < books.GetLength(0); i++)
    {
        if (i != bookId)
        {
            for (int j = 0; j < books.GetLength(1); j++)
            {
                newBooks[newId, j] = books[i, j];
            }
            newId++;
        }
    }
    return newBooks;
}


int GetNumberFromUser(string message)
{
    int? number = null;
    bool canParseToInt = false;
    while (!canParseToInt)
    {
        Console.WriteLine(message);
        canParseToInt = int.TryParse(Console.ReadLine(), out int result);
        if (!canParseToInt || result < 0)
        {
            canParseToInt = false;
            Console.WriteLine("Wrong Input");
        }
        number = result;
    }
    return number!.Value;
}