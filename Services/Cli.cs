namespace Library_Management_System.Services;

public class Cli
{
    private readonly Library.Library _library = new();

    public static bool ValidateCommand(int lenCommands, int numCommands)
    {
        if (lenCommands == numCommands) return true;
        Console.WriteLine("Invalid Command Please check <Usage>");
        return false;
    }
    public void Run()
    {
        while (true)
        {
            // Receiving command from user
            Console.WriteLine("\nEnter command (use help for usage info):\n");
            var command = Console.ReadLine()?.Trim().ToLower();
            var commandParts = command?.Split(' ');

            switch (commandParts?[0])
            {
                case "add_book":
                    
                    _library.AddBook(new Book.Book(
                        commandParts[1],
                        commandParts[2],
                        commandParts[3],
                        int.Parse(commandParts[4])
                    ));
                    break;

                case "register_member":
                    if (commandParts.Length != 3)
                    {
                        Console.WriteLine("Usage: register_member <name> <email>");
                        break;
                    }

                    _library.RegisterMember(
                        new Member.Member(
                            commandParts[1],
                            commandParts[2]
                        ));
                    
                    break;

                case "borrow_book":
                    if (commandParts.Length != 3)
                    {
                        Console.WriteLine("Usage: borrow_book <member_id> <isbn>");
                        break;
                    }

                    _library.BorrowBook(
                        commandParts[1],
                        commandParts[2]
                    );
                    break;

                case "return_book":
                    if (commandParts.Length != 3)
                    {
                        Console.WriteLine("Usage: return_book <member_id> <isbn>");
                        break;
                    }

                    _library.ReturnBook(
                        commandParts[1],
                        commandParts[2]
                    );
                    break;

                case "list_books":
                    _library.ListBooks();
                    break;

                case "list_members":
                    _library.ListMembers();
                    break;

                default:
                    Console.WriteLine("Usage:");
                    Console.WriteLine("add_book <title> <author> <isbn> <copies>");
                    Console.WriteLine("register_member <name> <email>");
                    Console.WriteLine("borrow_book <member_id> <isbn>");
                    Console.WriteLine("return_book <member_id> <isbn>");
                    Console.WriteLine("list_books");
                    Console.WriteLine("list_members");
                    break;
            }
        }
    }
}