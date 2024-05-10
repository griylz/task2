using WebApplication1.Model;

namespace WebApplication1.Controllers;

public interface IBooksRepository
{
    Task<bool> AddBook(Book book,BookEditions bookEditions);
    Task<List<Book>> GetEditionBooks(int id);
}