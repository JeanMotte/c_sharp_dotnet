using BiblioEventsConsole.Struct;
using System;

namespace BiblioEventsConsole.BookEventArgs
{
    /// <summary>
    /// Provides data for the BookAdded and BookRemoved events.
    /// </summary>
    public class BookEventArgs : EventArgs
    {
        public Book Book { get; }

        public BookEventArgs(Book book)
        {
            Book = book;
        }
    }
}