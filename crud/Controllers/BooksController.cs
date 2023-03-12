using crud.DAL;
using crud.DAL.BooksAPI.Models;
using crud.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace crud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class BooksController : ControllerBase
    {
        private readonly IBooksDAL _booksDAL;

        public BooksController(IConfiguration configuration)
        {
            // Create a new instance of the BooksDAL class with the database connection string
            _booksDAL = new BooksDAL(configuration);
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            // Call the GetBooks method in the BooksDAL class
            List<Book> books = await _booksDAL.GetBooks();

            // If there are no books, return a 404 error
            if (books == null)
            {
                return NotFound();
            }

            // Return the list of books
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            // Call the GetBook method in the BooksDAL class
            Book book = await _booksDAL.GetBook(id);

            // If the book is null, return a 404 error
            if (book == null)
            {
                return NotFound();
            }

            // Return the book
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddBook(Book book)
        {
            // Call the AddBook method in the BooksDAL class


            if (Convert.ToString(book.Title) != "" && Convert.ToString(book.Author) != "")
            {
                book.Id= await _booksDAL.AddBook(book);
                return Ok(book);
            }
            else {
                return Ok("Value missing");
            }


            // Return the new book ID
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, Book book)
        {
            // Call the UpdateBook method in the BooksDAL class
            int success = await _booksDAL.UpdateBook(id, book);

            // If the book was not updated, return a 404 error
            if (success==0)
            {
                return NotFound();
            }

            // Return a 204 (No Content) response
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            // Call the DeleteBook method in the BooksDAL class
            int success = await _booksDAL.DeleteBook(id);

            // If the book was not deleted, return a 404 error
            if (success>0)
            {
                return NotFound();
            }

            // Return a 204 (No Content) response
            return NoContent();
        }
    }

}
