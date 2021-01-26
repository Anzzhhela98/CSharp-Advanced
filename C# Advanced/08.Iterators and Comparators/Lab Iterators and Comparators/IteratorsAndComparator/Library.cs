using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public SortedSet<Book> books;
        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books);
        }
        public IEnumerator<Book> GetEnumerator() => books.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        //private class LibraryIterator : IEnumerator<Book>
        //{
        //    public List<Book> Books { get; set; }

        //    private int currentIndex = -1;
        //    public LibraryIterator(List<Book> books)
        //    {
        //        this.Books = books;
        //    }

        //    public Book Current => this.Books[currentIndex];

        //    object IEnumerator.Current => this.Current;

        //    public void Dispose()
        //    {
        //        throw new NotImplementedException();
        //    }
        //    public bool MoveNext()
        //    {
        //        this.currentIndex++;

        //        if (this.currentIndex >= this.Books.Count)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }

        //    public void Reset()
        //    {
        //        this.currentIndex = -1;
        //    }
    }
}

