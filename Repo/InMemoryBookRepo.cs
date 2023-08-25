using FirstWebAPI_March16.Models;

namespace FirstWebAPI_March16.Repo
{
    public class InMemoryBookRepo
    {
        private List<Book> _books;
        public InMemoryBookRepo()
        {
            _books = new()
            {
                new Book
                {
                    Id = 1,
                    title = "Java",
                    price = 500
                }
            };
        }

        public void CreateBook(Book book)
        {
            _books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var bookIndex = _books.FindIndex(x => x.Id == id);
            _books.RemoveAt(bookIndex);
        }

        public Book GetBook(int id)
        {
            var book = _books.Where(x => x.Id == id).SingleOrDefault();

            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            try
            {
                return _books;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateBook(int id, Book book)
        {
            var bookind = _books.FindIndex(x => x.Id == id);
            _books[bookind]= book;
        }
    }
}
