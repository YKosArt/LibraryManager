using System;
using System.Collections.Generic;

class LibraryManager
{
    static Dictionary<string, bool> libraryBooks = new Dictionary<string, bool>();
    const int maxLibraryCapacity = 5;
    const int maxBorrowedBooks = 3;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Would you like to add, remove, search, borrow, return, or exit? (add/remove/search/borrow/return/exit)");
            string userAction = Console.ReadLine()?.Trim().ToLower();

            switch (userAction)
            {
                case "add":
                    AddBook();
                    break;
                case "remove":
                    RemoveBook();
                    break;
                case "search":
                    SearchBook();
                    break;
                case "borrow":
                    BorrowBook();
                    break;
                case "return":
                    ReturnBook();
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Invalid action. Please type 'add', 'remove', 'search', 'borrow', 'return', or 'exit'.");
                    break;
            }

            DisplayBooks();
        }
    }

    static void AddBook()
    {
        if (libraryBooks.Count >= maxLibraryCapacity)
        {
            Console.WriteLine("The library is full. No more books can be added.");
            return;
        }

        Console.WriteLine("Enter the title of the book to add:");
        string bookTitleToAdd = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(bookTitleToAdd))
        {
            Console.WriteLine("Book title cannot be empty.");
            return;
        }

        if (libraryBooks.ContainsKey(bookTitleToAdd))
        {
            Console.WriteLine($"The book '{bookTitleToAdd}' already exists in the library.");
            return;
        }

        libraryBooks.Add(bookTitleToAdd, false); // Додаємо книгу як доступну
        Console.WriteLine($"Book '{bookTitleToAdd}' added to the library.");
    }

    static void RemoveBook()
    {
        if (libraryBooks.Count == 0)
        {
            Console.WriteLine("The library is empty. No books to remove.");
            return;
        }

        Console.WriteLine("Enter the title of the book to remove:");
        string bookTitleToRemove = Console.ReadLine();

        if (libraryBooks.ContainsKey(bookTitleToRemove))
        {
            if (libraryBooks[bookTitleToRemove])
            {
                Console.WriteLine($"The book '{bookTitleToRemove}' is currently borrowed and cannot be removed.");
            }
            else
            {
                libraryBooks.Remove(bookTitleToRemove);
                Console.WriteLine($"Book '{bookTitleToRemove}' removed from the library.");
            }
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    static void SearchBook()
    {
        Console.WriteLine("Enter the title of the book to search:");
        string bookTitleToSearch = Console.ReadLine();
        if (libraryBooks.ContainsKey(bookTitleToSearch))
        {
            bool isBorrowed = libraryBooks[bookTitleToSearch];
            if (isBorrowed)
            {
                Console.WriteLine($"Book '{bookTitleToSearch}' is currently borrowed.");
            }
            else
            {
                Console.WriteLine($"Book '{bookTitleToSearch}' is available in the library.");
            }
        }
        else
        {
            Console.WriteLine($"Book '{bookTitleToSearch}' is not in the library.");
        }
    }

    static void BorrowBook()
    {
        if (libraryBooks.Count == 0)
        {
            Console.WriteLine("The library is empty. No books to borrow.");
            return;
        }

        Console.WriteLine("Enter the title of the book to borrow:");
        string bookTitleToBorrow = Console.ReadLine();

        if (libraryBooks.ContainsKey(bookTitleToBorrow))
        {
            if (libraryBooks[bookTitleToBorrow])
            {
                Console.WriteLine($"The book '{bookTitleToBorrow}' is already borrowed.");
            }
            else
            {
                libraryBooks[bookTitleToBorrow] = true; // Позначаємо книгу як позичену
                Console.WriteLine($"Book '{bookTitleToBorrow}' borrowed successfully.");
            }
        }
        else
        {
            Console.WriteLine("Book not found in the library.");
        }
    }

    static void ReturnBook()
    {
        Console.WriteLine("Enter the title of the book to return:");
        string bookTitleToReturn = Console.ReadLine();

        if (libraryBooks.ContainsKey(bookTitleToReturn))
        {
            if (libraryBooks[bookTitleToReturn])
            {
                libraryBooks[bookTitleToReturn] = false; // Позначаємо книгу як доступну
                Console.WriteLine($"Book '{bookTitleToReturn}' returned successfully.");
            }
            else
            {
                Console.WriteLine("This book is not currently borrowed.");
            }
        }
        else
        {
            Console.WriteLine("Book not found in the library.");
        }
    }

    static void DisplayBooks()
    {
        Console.WriteLine("Library books:");
        if (libraryBooks.Count == 0)
        {
            Console.WriteLine("No books in the library.");
        }
        else
        {
            foreach (var book in libraryBooks)
            {
                string status = book.Value ? "[Borrowed]" : "[Available]";
                Console.WriteLine($"{book.Key} {status}");
            }
        }
    }
}


