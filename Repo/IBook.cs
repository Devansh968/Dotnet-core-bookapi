using FirstWebAPI_March16.Models;

namespace FirstWebAPI_March16.Repo
{
    public interface IBook
    {
        public IEnumerable<Book> GetBooks();
        public Book GetBook(int id);
        public void CreateBook(Book book);
        public void UpdateBook(int id,Book book);
        public void DeleteBook(int id);

    }
}
