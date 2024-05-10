using Microsoft.Data.SqlClient;
using WebApplication1.Model;

namespace WebApplication1.Controllers;

public class BookRepository : IBooksRepository
{
    private readonly IConfiguration _configuration;

    public BookRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<bool> AddBook(Book book,BookEditions bookEditions)
    {
        
        await using var connection = new SqlConnection(_configuration.GetConnectionString("2019SBD"));
        await connection.OpenAsync();
        await using var transaction = connection.BeginTransaction();
        try
        {


            await using var command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = @"INSERT INTO books(title)
                            VALUES (@Title);";
            var bookId = await command.ExecuteScalarAsync();
            command.CommandText =
                @"insert into books_editions(fk_publishing_house, fk_book, edition_title, release_date)
                              values (@PublishingHouse,@Book,@EditionTitle,@ReleaseDate);
                            ";

            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@PublishingHouse", bookEditions.FkPublishingHouseId);
            command.Parameters.AddWithValue("@Book", book.Pk);
            command.Parameters.AddWithValue("@EditionTitle", bookEditions.EditionTitle);
            command.Parameters.AddWithValue("@@ReleaseDate", bookEditions.ReleaseDate);
            await command.ExecuteNonQueryAsync();
            transaction.Commit();
            if (bookId != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {   
            transaction.Rollback();
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Book>> GetEditionBooks(int id)
    {
        await using var connection = new SqlConnection(_configuration.GetConnectionString("2019SBD"));
        await connection.OpenAsync();
        await using var command = new SqlCommand();
        command.Connection = connection;
        return new List<Book>();
    }
}