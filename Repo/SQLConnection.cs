using FirstWebAPI_March16.Dtos;
using FirstWebAPI_March16.Models;
using System.Data.SqlClient;

namespace FirstWebAPI_March16.Repo
{
    public class SQLConnection : IBook
    {
        private readonly IConfiguration _configuration;
        private List<Book> _books = new List<Book>();

        public SQLConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void CreateBook(Book book)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("BooksDatabase")))
            {
                var sql = $"insert into Books(title,price) values('{book.title}',{book.price})";
                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
            }
        }

        public void DeleteBook(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("BooksDatabase")))
            {
                var sql = $"delete from Books where Id={id}";
                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
            }
        }

        public Book GetBook(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("BooksDatabase")))
            {
                try
                {
                    var sql = $"select * from Books where Id={id}";
                    connection.Open();
                    using SqlCommand command = new SqlCommand(sql, connection);
                    using SqlDataReader reader = command.ExecuteReader();
                    var book = new Book();
                    if (reader.Read())
                    {
                        book.Id = (int)reader["id"];
                        book.title = reader["title"].ToString();
                        book.price = (decimal)reader["price"];
                    }
                    return book;

                }
                catch (Exception) 
                {
                    throw;
                }
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("BooksDatabase")))
            {
                var sql = "select * from Books";
                connection.Open();
                if(_books!=null)
                {
                    _books = new List<Book>(); ;
                }
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var book = new Book()
                    {
                        Id = (int)reader["Id"],
                        title = reader["title"].ToString(),
                        price = (decimal)reader["price"]
                    };
                    _books.Add(book);
                }
            }

            return _books;
        }

        public void UpdateBook(int id, Book book)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("BooksDatabase")))
            {
                var sql = $"UPDATE Books SET title = '{book.title}', price='{book.price}' WHERE ID = {id};";
                connection.Open();
                using SqlCommand command = new SqlCommand(sql, connection);
                using SqlDataReader reader = command.ExecuteReader();
            }
        }
    }
}
