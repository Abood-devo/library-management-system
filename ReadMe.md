# Library Management System Documentation

## Overview

The Library Management System is a C# application designed to manage books, members, and borrowing transactions. It operates through a command-line interface (CLI) and leverages object-oriented programming principles to ensure clean, maintainable, and efficient code. This documentation provides detailed information about the classes, methods, and functionalities of the system.

## Classes and Methods

### Class: Book

#### Properties
- `Title`: The title of the book.
- `Author`: The author of the book.
- `ISBN`: The International Standard Book Number of the book.
- `CopiesAvailable`: The number of copies available for borrowing.

#### Methods
- `Book(string title, string author, string isbn, int copiesAvailable)`: Constructor to initialize the book details and validate the ISBN.
- `bool Borrow()`: Reduces the `CopiesAvailable` by one if copies are available. Returns `true` if successful, otherwise `false`.
- `void Return()`: Increases the `CopiesAvailable` by one.
- `bool IsAvailable()`: Checks if any copies are available for borrowing. Returns `true` if available, otherwise `false`.
- `override string ToString()`: Returns a string representation of the book's details.

#### Private Methods
- `bool IsValidIsbn()`: Validates the ISBN format.
- `void ValidateIsbn()`: Throws an exception if the ISBN is invalid.

### Class: Member

#### Properties
- `MemberID`: The unique identifier for the member.
- `Name`: The name of the member.
- `Email`: The email address of the member.
- `BorrowedBooks`: A list of books borrowed by the member.

#### Methods
- `Member(string name, string email)`: Constructor to initialize the member details and validate the email.
- `void BorrowBook(Book book)`: Allows the member to borrow a book if it is available.
- `void ReturnBook(Book book)`: Allows the member to return a borrowed book.
- `override string ToString()`: Returns a string representation of the member's details, including borrowed books.

#### Private Methods
- `void ValidateEmail(string email)`: Validates the email format.

### Class: Library

#### Properties
- `List<Book> Books`: A list of books available in the library.
- `List<Member> Members`: A list of registered library members.

#### Methods
- `Library()`: Constructor to initialize the books and members lists.
- `void AddBook(Book book)`: Adds a new book to the library.
- `void RegisterMember(Member member)`: Registers a new member to the library.
- `void BorrowBook(string memberID, string isbn)`: Allows a member to borrow a book if available.
- `void ReturnBook(string memberID, string isbn)`: Allows a member to return a borrowed book.
- `void ListBooks()`: Displays the list of all books in the library.
- `void ListMembers()`: Displays the list of all registered members.

### Class: CommandLineInterface

#### Methods
- `CommandLineInterface()`: Constructor to initialize the library.
- `void Run()`: Runs the command-line interface, processing user commands to interact with the library.

### Class: Program

#### Methods
- `static void Main()`: The entry point of the application. It initializes and runs the command-line interface.

## Command-Line Interface

The CLI provides various commands to interact with the library. The available commands are:

- `add_book <title> <author> <isbn> <copies>`: Adds a new book to the library.
- `register_member <name> <email>`: Registers a new member.
- `borrow_book <member_id> <isbn>`: Allows a member to borrow a book.
- `return_book <member_id> <isbn>`: Allows a member to return a borrowed book.
- `list_books`: Lists all books in the library.
- `list_members`: Lists all registered members.

### Usage Example

1. **Adding a New Book**:
   ```
   add_book Clean-Code Abdulqader 9780743273565 3
   ```
2. **Registering a New Member**:
   ```
   register_member Abdulah abd@devnas.com
   ```
3. **Listing All Members (to get the id)**:
   ```
   list_members
   ```
4. **Borrowing a Book**:
   ```
   borrow_book <memberid> 9780743273565
   ```
5. **Listing All Books (number of copies will decrease)**:
   ```
   list_books
   ```
6. **Returning a Book(number of copies will increase)**:
   ```
   return_book <memberid> 9780743273565
   ```

## Conclusion

This documentation provides an overview of the Library Management System, detailing its classes, methods, and functionalities. The system is designed to be user-friendly and efficient, leveraging object-oriented programming principles to ensure maintainability and scalability. The command-line interface allows easy interaction with the library, making it a robust solution for managing library operations.

[//]: # (- ```add_book Clean-code Abdulqader 0061964360 5```)

[//]: # (- ```list_books```)

[//]: # (- ```register_member dada dada@devnas.com```)

[//]: # (- ```list_members```)

[//]: # (- ```borrow_book```)

[//]: # (- ```return_book```)

[//]: # (- mohammad &#40;6899d&#41;)

[//]: # ( - abdulah &#40;5625c&#41;)