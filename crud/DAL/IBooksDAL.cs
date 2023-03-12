using crud.Model;

namespace crud.DAL
{
    public interface IBooksDAL
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<int> AddBook(Book book);
        Task<int> UpdateBook(int id, Book book);
        Task<int> DeleteBook(int id);
    }
}
