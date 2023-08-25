using FirstWebAPI_March16.Dtos;
using FirstWebAPI_March16.Models;
using FirstWebAPI_March16.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI_March16.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBook _booksRepo;
        public BooksController(IBook booksRepo)
        { 
            _booksRepo = booksRepo;
         
        }

        [HttpPost]
        public ActionResult CreateBook(CreateOrUpdateBookDTO book)
        {
            var newBook = new Book();
            newBook.title = book.Title;
            newBook.price = book.Price;
            _booksRepo.CreateBook(newBook);

             return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<BookDTO> GetBook(int id)
        {
            var book = _booksRepo.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return new BookDTO { Id = book.Id, Title = book.title, Price = book.price };
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetBooks()
        {
            var books = _booksRepo.GetBooks().Select(x => new BookDTO { Id = x.Id, Title = x.title, Price = x.price }).ToList();
            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        [HttpPut]
        public ActionResult UpdateBook(int id, CreateOrUpdateBookDTO book)
        {
            var updatebook = _booksRepo.GetBook(id);
            if (updatebook == null)
            {
                return NotFound();
            }
            updatebook.title = book.Title;
            updatebook.price = book.Price;
            _booksRepo.UpdateBook(id, updatebook);

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteBook(int id)
        {
            _booksRepo.DeleteBook(id);
            
            return Ok();
        }
    }
}
