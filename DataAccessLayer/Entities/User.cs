using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer;

public record User
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }
    public string ContactNo { get; set; }
    public string Role { get; set; }
}