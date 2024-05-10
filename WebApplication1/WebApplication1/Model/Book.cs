using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Pk { get; set; }
    public string Title { get; set; }
}

public class BookEditions
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Pk { get; set; }
    public int FkPublishingHouseId { get; set; }
    public int FkBook { get; set; }
    public string EditionTitle { get; set; }
    public DateTime ReleaseDate { get; set; }
}