namespace zero_hunger.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Restaurant
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string DisplayName { get; set; } = null!;
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;
}
