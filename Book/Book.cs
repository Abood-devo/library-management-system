namespace Library_Management_System.Book;

public class Book
{
    public Book(string title, string author, string isbn, int copiesAvailable)
    {

        Title = title;
        Author = author;
        ValidateIsbn(isbn);

        Isbn = isbn;
        CopiesAvailable = copiesAvailable;
    }

    // Properties
    public string Title { get; }
    public string Author { get; }
    public string Isbn { get; }
    public int CopiesAvailable { get; set; }

    // Method to borrow a book
    public bool Borrow()
    {
        if (CopiesAvailable <= 0) return false;
        CopiesAvailable--;
        return true;
    }

    // Method to return a book
    public void Return()
    {
        CopiesAvailable++;
    }

    private bool IsValidIsbn(string isbn)
    {
        return isbn.Length > 5 & isbn.Length < 14;
    }

    private void ValidateIsbn(string isbn)
    {
        if (!IsValidIsbn(isbn)) throw new ArgumentException("Invalid ISBN format.");
    }

    public bool IsAvailable()
    {
        return CopiesAvailable > 0;
    }

    // Overriding ToString method
    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, ISBN: {Isbn}, Copies Available: {CopiesAvailable}";
    }
}