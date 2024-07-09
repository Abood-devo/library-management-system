namespace Library_Management_System.Library;
using Member;

public class Library
{
    private List<Book.Book> Books { get; set; } = [];
    private List<Member> Members { get; set; } = [];

    // Method to add a book to the library
    public void AddBook(Book.Book book)
    {
        Books.Add(book);
        Console.WriteLine($"Added book: {book.Title} by {book.Author}");
    }

    // Method to add a member to the library
    public void RegisterMember(Member member)
    {
        Members.Add(member);
        Console.WriteLine($"Added member: {member.Name}");
    }

    // Method to borrow a book
    public void BorrowBook(string memberid, string isbn)
    {
        var member = Members.Find(m => m.Memberid == memberid);
        if (member == null)
        {
            Console.WriteLine($"Member with ID {memberid} not found.");
            return;
        }

        var book = Books.Find(b => b.Isbn == isbn);
        if (book == null)
        {
            Console.WriteLine($"The book with ISBN {isbn} is not available in the library.");
            return;
        }

        if (book.IsAvailable())
        {
            member.BorrowBook(book);
            Console.WriteLine($"{member.Name} borrowed {book.Title}");
        }
        else
        {
            Console.WriteLine($"The book {book.Title} is not available for borrowing.");
        }
    }

    // Method to return a book
    public void ReturnBook(string memberid, string isbn)
    {
        var member = Members.Find(m => m.Memberid == memberid);
        if (member == null)
        {
            Console.WriteLine($"Member with ID {memberid} not found.");
            return;
        }

        var book = member.BorrowedBooks.Find(b => b.Isbn == isbn);
        if (book == null)
        {
            Console.WriteLine($"{member.Name} did not borrow the book with ISBN {isbn}.");
            return;
        }

        member.ReturnBook(book);
        Console.WriteLine($"{member.Name} returned {book.Title}");
    }

    // Method to display books information
    public void ListBooks()
    {
        Console.WriteLine("Library Books:");
        foreach (var book in Books)
            Console.WriteLine(
                $" - {book.Title} by {book.Author}, Copies Available: {book.CopiesAvailable}, ISBN: {book.Isbn}");
    }

    // Method to display members information
    public void ListMembers()
    {
        Console.WriteLine("Library Members:");
        foreach (var member in Members) Console.WriteLine($" - {member.Name} ({member.Memberid})");
    }
}