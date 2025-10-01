using BiblioEventsConsole.Struct;
using BiblioEventsConsole.Enum;

public class Book
{
    public string Title { get; set; }
    public Author Author { get; set; } // max 1 author because class type
    public Category Category { get; set; }
    public Color Color { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="title"></param>
    /// <param name="author"></param>
    /// <param name="category"></param>
    /// <param name="coverColor"></param>
    public Book(string title, Author author, Category category, Color color)
    {
        Title = title;
        Author = author;
        Category = category;
        Color = color;
    }

    /// <summary>
    /// Override ToString method
    /// </summary>
    /// <returns>
    /// A string representation of the book.
    /// </returns>
    public override string ToString()
    {
        return $"\"{Title}\" by {Author}, Category: {Category}, Color: {Color}";
    }


    /// <summary>
    /// Override equality operator
    /// </summary>
    /// <param name="b1"></param>
    /// <param name="b2"></param>
    /// <returns>
    /// True if the books title AND author are identical, false otherwise.
    /// </returns>
    public static bool operator ==(Book b1, Book b2)
    {
        if (ReferenceEquals(b1, b2))
            return true;
        if (b1 is null || b2 is null)
            return false;
        return b1.Title == b2.Title && b1.Author.Equals(b2.Author);
    }

    /// <summary>
    /// Override inequality operator
    /// </summary>
    /// <param name="b1"></param>
    /// <param name="b2"></param>
    /// <returns>
    /// True if the books title AND author are NOT identical, false otherwise.
    /// </returns>
    public static bool operator !=(Book b1, Book b2)
    {
        return !(b1 == b2);
    }

    /// <summary>
    /// Override Equals method
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>
    /// True if the books title AND author are identical, false otherwise.
    /// </returns>
    public override bool Equals(object? obj)
    {
        if (obj is Book otherBook)
        {
            return this == otherBook;
        }
        return false;
    }

    /// <summary>
    /// Override GetHashCode method
    /// </summary>
    /// <returns>
    /// A hash code for the book.
    /// </returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Author);
    }
}