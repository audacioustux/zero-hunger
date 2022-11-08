namespace zero_hunger.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User : Helper.BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string DisplayName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool IsEmployee { get; set; }
}