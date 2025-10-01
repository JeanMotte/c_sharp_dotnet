using BiblioEventsConsole.Enum;
using BiblioEventsConsole.Struct;
using System.Collections.Generic;
using BiblioEventsConsole.BookEventArgs;
using System;
using System.Linq;

/// <summary>
/// Represents a library containing a collection of books.
/// </summary>
public class Library
{
    private readonly List<Book> books = new List<Book>();

    /// <summary>
    /// Event raised when a book is added to the library.
    /// </summary>
    public event EventHandler<BookEventArgs>? BookAdded;

    /// <summary>
    /// Event raised when a book is removed from the library.
    /// </summary>
    public event EventHandler<BookEventArgs>? BookRemoved;

    /// <summary>
    /// Indexer to access a book by its index.
    /// </summary>
    public Book this[int index]
    {
        get { return books[index]; }
        set { books[index] = value; }
    }

    /// <summary>
    /// Adds a book to the library and raises the BookAdded event.
    /// </summary>
    /// <param name="book">The book to add.</param>
    public void AddBook(Book book)
    {
        books.Add(book);
        OnBookAdded(new BookEventArgs(book));
    }

    /// <summary>
    /// Removes a book from the library and raises the BookRemoved event.
    /// </summary>
    /// <param name="book">The book to remove.</param>
    public void RemoveBook(Book book)
    {
        if (books.Remove(book))
        {
            OnBookRemoved(new BookEventArgs(book));
        }
    }

    /// <summary>
    /// Searches for books by category using a switch expression.
    /// </summary>
    /// <param name="category">The category to search for.</param>
    /// <returns>A list of books in the specified category.</returns>
    public List<Book> SearchByCategory(Category category)
    {
        var foundBooks = new List<Book>();
        foreach (var book in books)
        {
            switch (book.Category)
            {
                case Category.Roman:
                case Category.Essai:
                case Category.BD:
                case Category.Science:
                    if (book.Category == category)
                    {
                        foundBooks.Add(book);
                    }
                    break;
            }
        }
        return foundBooks;
    }

    /// <summary>
    /// Searches for books by color using a switch expression.
    /// </summary>
    /// <param name="color">The color to search for.</param>
    /// <returns>A list of books with the specified color.</returns>
    public List<Book> SearchByColor(Color color)
    {
        var foundBooks = new List<Book>();
        foreach (var book in books)
        {
            switch (book.Color)
            {
                case Color.Red:
                case Color.Blue:
                case Color.Green:
                case Color.White:
                    if (book.Color == color)
                    {
                        foundBooks.Add(book);
                    }
                    break;
            }
        }
        return foundBooks;
    }

    /// <summary>
    /// Searches for books by author.
    /// </summary>
    /// <param name="author">The author to search for.</param>
    /// <returns>A list of books by the specified author.</returns>
    public List<Book> SearchByAuthor(Author author)
    {
        return books.Where(b => b.Author.Equals(author)).ToList();
    }

    /// <summary>
    /// Returns a list of books within a specified index range.
    /// </summary>
    /// <param name="start">The starting index.</param>
    /// <param name="end">The ending index.</param>
    /// <returns>A list of books within the range.</returns>
    public List<Book> DisplayRange(int start, int end)
    {
        return books.Skip(start).Take(end - start + 1).ToList();
    }

    /// <summary>
    /// Raises the BookAdded event.
    /// </summary>
    /// <param name="e">The event arguments.</param>
    protected virtual void OnBookAdded(BookEventArgs e)
    {
        BookAdded?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the BookRemoved event.
    /// </summary>
    /// <param name="e">The event arguments.</param>
    protected virtual void OnBookRemoved(BookEventArgs e)
    {
        BookRemoved?.Invoke(this, e);
    }

    /// <summary>
    /// Gets a read-only list of all books in the library to safely expose the internal list.
    /// </summary>
    public IReadOnlyList<Book> GetAllBooks()
    {
        return books.AsReadOnly();
    }
}