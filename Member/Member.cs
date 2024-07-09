using System.Net.Mail;

namespace Library_Management_System.Member;

public class Member
{
    public Member(string name, string email)
    {
        Memberid = Guid.NewGuid().ToString("D")[..5];
        Name = name;
        Email = email;
        BorrowedBooks = new List<Book.Book>();
        ValidateEmail(email);
    }

    // Properties
    public string Memberid { get; }
    public string Name { get; }
    private string Email { get; }
    public List<Book.Book> BorrowedBooks { get; }

    // Method to borrow a book
    public void BorrowBook(Book.Book book)
    {
        if (book.IsAvailable() && book.Borrow()) BorrowedBooks.Add(book);
    }

    // Method to return a book
    public void ReturnBook(Book.Book book)
    {
        if (BorrowedBooks.Contains(book))
        {
            book.Return();
            BorrowedBooks.Remove(book);
        }
    }

    // Method to generate a unique ID
    public string Generateid()
    {
        return Guid.NewGuid().ToString("D");
    }

    // Method to validate email address
    private void ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email)) throw new ArgumentException("Email address cannot be null or empty.");
        try
        {
            var emailAddress = new MailAddress(email);
        }
        catch
        {
            throw new ArgumentException("Invalid Email Address, Please consider entering a valid email.");
        }
    }

    // Overriding ToString method
    public override string ToString()
    {
        var borrowedBooksInfo = BorrowedBooks.Count > 0
            ? string.Join(", ", BorrowedBooks.ConvertAll(book => $"{book.Title} by {book.Author}"))
            : "No borrowed books";
        return $"Member ID: {Memberid}\nName: {Name}\nEmail: {Email}\nBorrowed Books: {borrowedBooksInfo}";
    }
}