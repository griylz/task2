using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Model.DTO;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBooksRepository _booksRepository;

    public BooksController(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    [HttpPost]
    private async Task<IActionResult> AddBook([FromBody]BookDTO bookDto)
    {
        var book = new Book()
        {
            Title = bookDto.BookTitle
        };
        var editions = new BookEditions()
        {
            FkPublishingHouseId = bookDto.PublishingHouseId,
            FkBook = book.Pk,
            EditionTitle = bookDto.EditionTitle,
            ReleaseDate = bookDto.ReleaseDate
        };

        await _booksRepository.AddBook(book, editions);
        return Ok();
    }
    
    
}