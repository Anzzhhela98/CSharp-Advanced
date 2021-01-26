using System.Collections;
using System.Collections.Generic;


namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public SortedSet<Book> books;
        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books, new BookComparator());
        }
        public IEnumerator<Book> GetEnumerator() => books.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
