using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model.DTO;

public class BookDTO
{
    
    [Required]
    public string BookTitle { get; set; }
    [Required]
    public int PublishingHouseId { get; set; }
    [Required]
    public string EditionTitle { get; set; }
    [Required]
    public DateTime ReleaseDate { get; set; }
}