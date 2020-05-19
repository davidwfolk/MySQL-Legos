using System.ComponentModel.DataAnnotations;

namespace legodb.Models
{
  public class Lego
  {
    public int Id { get; set; }
    [Required]
    [MaxLength(80)]
    public string Title { get; set; }
    public string CreatorEmail { get; set; }
  }

  public class TagLegoViewModel : Lego
  {
    public int TagLegoId { get; set; }
    public string Tag { get; set; }
  }

}