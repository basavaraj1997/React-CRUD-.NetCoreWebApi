using crud.Model;
using System.Data.SqlClient;

namespace crud.DAL
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;

    namespace BooksAPI.Models
    {
        public class BooksDAL : IBooksDAL
        {
            private readonly string _connectionString;

            public BooksDAL(IConfiguration configuration)
            {
                // Get the database connection string from the appsettings.json file
                _connectionString = configuration.GetConnectionString("BooksDatabase");
            }

            public async Task<List<Book>> GetBooks()
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // Create a new SqlCommand object with a SELECT statement
                    SqlCommand command = new SqlCommand("SELECT * FROM Books", connection);

                    // Open the database connection
                    await connection.OpenAsync();

                    // Execute the SELECT statement and get a SqlDataReader object
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    // Create a new list of books
                    List<Book> books = new List<Book>();

                    // Loop through the SqlDataReader and add each book to the list
                    while (await reader.ReadAsync())
                    {
                        Book book = new Book()
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            PublicationDate = reader.GetDateTime(3),
                            ISBN = reader.GetString(4)
                        };
                        books.Add(book);
                    }

                    // Close the SqlDataReader and the database connection
                    reader.Close();
                    connection.Close();

                    // Return the list of books
                    return books;
                }
            }

            public async Task<Book> GetBook(int id)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // Create a new SqlCommand object with a SELECT statement and a parameter
                    SqlCommand command = new SqlCommand("SELECT * FROM Books WHERE Id=@Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    // Open the database connection
                    await connection.OpenAsync();

                    // Execute the SELECT statement and get a SqlDataReader object
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    // If there are no rows, return null
                    if (!reader.HasRows)
                    {
                        reader.Close();
                        connection.Close();
                        return null;
                    }

                    // Read the first row and create a new Book object
                    await reader.ReadAsync();
                    Book book = new Book()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Author = reader.GetString(2),
                        PublicationDate = reader.GetDateTime(3),
                        ISBN = reader.GetString(4)
                    };

                    // Close the SqlDataReader and the database connection
                    reader.Close();
                    connection.Close();

                    // Return the Book object
                    return book;
                }
            }

            public async Task<int> AddBook(Book book)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // Create a new SqlCommand object with an INSERT statement and parameters
                    SqlCommand command = new SqlCommand("INSERT INTO Books (Title, Author, PublicationDate, ISBN) VALUES (@Title, @Author, @PublicationDate, @ISBN); SELECT SCOPE_IDENTITY();", connection);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@PublicationDate", book.PublicationDate);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);

                    // Open the database connection
                    await connection.OpenAsync();

                    // Execute the INSERT statement and get the new ID
                    int id = (int)(decimal)await command.ExecuteScalarAsync();

                    // Close the database connection
                    connection.Close();

                    // Return the new ID
                    return id;
                }
            }

            public async Task<int> UpdateBook(int id, Book book)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // Create a new SqlCommand object with an UPDATE statement and parameters
                    SqlCommand command = new SqlCommand("UPDATE Books SET Title=@Title, Author=@Author, PublicationDate=@PublicationDate, ISBN=@ISBN WHERE Id=@Id", connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@PublicationDate", book.PublicationDate);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);

                    // Open the database connection
                    await connection.OpenAsync();

                    // Execute the UPDATE statement and get the number of rows affected
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    // Close the database connection
                    connection.Close();

                    // Return the number of rows affected
                    return rowsAffected;
                }
            }

            public async Task<int> DeleteBook(int id)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    // Create a new SqlCommand object with a DELETE statement and a parameter
                    SqlCommand command = new SqlCommand("DELETE FROM Books WHERE Id=@Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    // Open the database connection
                    await connection.OpenAsync();

                    // Execute the DELETE statement and get the number of rows affected
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    // Close the database connection
                    connection.Close();

                    // Return the number of rows affected
                    return rowsAffected;
                }
            }
        }
    }
}
