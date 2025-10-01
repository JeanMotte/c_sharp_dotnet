using BiblioEventsConsole.Enum;
using BiblioEventsConsole.Struct;
using BiblioEventsConsole.BookEventArgs;
using System;
using System.Collections.Generic;

/// <summary>
/// Main program that:
/// - subscribe to events
/// - init the library with some data
/// - run interactive menu
/// - unsubscribe from events before exiting
/// </summary>
public class Program
{
    // Declare library at the class level to be accessible by all methods
    private static readonly Library library = new Library();

    public static void Main(string[] args)
    {
        // Subscribe to events
        library.BookAdded += OnBookAdded;
        library.BookRemoved += OnBookRemoved;

        // Init library with some books
        InitializeLibrary();

        // Start interactive menu
        RunMenu();

        // Unsubscribe from events before exiting
        library.BookAdded -= OnBookAdded;
        library.BookRemoved -= OnBookRemoved;
    }

    /// <summary>
    /// Runs the main interactive console menu.
    /// </summary>
    private static void RunMenu()
    {
        while (true)
        {
            Console.WriteLine("\n--- MY LIBRARY +> MENU ---");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Display all books");
            Console.WriteLine("3. Search by category");
            Console.WriteLine("4. Exit");
            Console.Write("Choice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddBookFromUserInput();
                    break;
                case "2":
                    DisplayAllBooks();
                    break;
                case "3":
                    SearchByCategory();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    /// <summary>
    /// Prompts the user for book details and adds it to the library.
    /// </summary>
    private static void AddBookFromUserInput()
    {
        try
        {
            Console.Write("Book title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Author's first name: ");
            string firstName = Console.ReadLine() ?? "";

            Console.Write("Author's last name: ");
            string lastName = Console.ReadLine() ?? "";

            Console.Write("Author's birth date (yyyy-mm-dd): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine() ?? "");

            // Use helper function to get enum choice
            Category category = GetEnumChoice<Category>("Category");
            Color color = GetEnumChoice<Color>("Color");

            // Create objects and add the book
            Author author = new Author(firstName, lastName, birthDate);
            Book newBook = new Book(title, author, category, color);
            library.AddBook(newBook);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding book: {ex.Message}");
        }
    }

    /// <summary>
    /// Displays all books currently in the library.
    /// </summary>
    private static void DisplayAllBooks()
    {
        Console.WriteLine("\n--- ALL BOOKS ---");
        var allBooks = library.GetAllBooks();
        if (allBooks.Count == 0)
        {
            Console.WriteLine("The library is empty.");
            return;
        }

        foreach (var book in allBooks)
        {
            Console.WriteLine(book.ToString());
        }
    }

    /// <summary>
    /// Prompts the user for a category and displays matching books.
    /// </summary>
    private static void SearchByCategory()
    {
        try
        {
            Category category = GetEnumChoice<Category>("Search by Category");
            var foundBooks = library.SearchByCategory(category);

            Console.WriteLine($"\n--- BOOKS IN CATEGORY: {category} ---");
            if (foundBooks.Count == 0)
            {
                Console.WriteLine("No books found in this category.");
            }
            else
            {
                foreach (var book in foundBooks)
                {
                    Console.WriteLine(book.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during search: {ex.Message}");
        }
    }

    /// <summary>
    /// Generic helper method to get a valid enum choice from the user.
    /// </summary>
    private static T GetEnumChoice<T>(string prompt) where T : struct, Enum
    {
        Console.WriteLine($"--- Select a {prompt} ---");
        var enumValues = Enum.GetValues(typeof(T)).Cast<T>().ToList();

        for (int i = 0; i < enumValues.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {enumValues[i]}");
        }

        while (true)
        {
            Console.Write("Choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= enumValues.Count)
            {
                return enumValues[choice - 1];
            }
            Console.WriteLine("Invalid selection. Please try again.");
        }
    }

    /// <summary>
    /// Adds some initial data to the library.
    /// </summary>
    private static void InitializeLibrary()
    {
        library.AddBook(new Book("The Stranger", new Author("Albert", "Camus", new DateTime(1975, 1, 1)), Category.Roman, Color.Green));
        library.AddBook(new Book("Dune", new Author("Frank", "Herbert", new DateTime(1975, 1, 1)), Category.Essai, Color.White));
        library.AddBook(new Book("Foundation", new Author("Isaac", "Asimov", new DateTime(1975, 1, 1)), Category.BD, Color.Blue));
        library.AddBook(new Book("1984", new Author("George", "Orwell", new DateTime(1975, 1, 1)), Category.Science, Color.Red));
    }

    #region Event Handlers

    /// <summary>
    /// Method called when the BookAdded event is raised.
    /// </summary>
    private static void OnBookAdded(object? sender, BookEventArgs e)
    {
        Console.WriteLine($"---> EVENT: Book added successfully: {e.Book.Title}");
    }

    /// <summary>
    /// Method called when the BookRemoved event is raised.
    /// </summary>
    private static void OnBookRemoved(object? sender, BookEventArgs e)
    {
        Console.WriteLine($"---> EVENT: Book removed successfully: {e.Book.Title}");
    }

    #endregion
}