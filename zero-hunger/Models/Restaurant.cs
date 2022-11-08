namespace zero_hunger.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Restaurant : Helper.BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string DisplayName { get; set; } = null!;
    public string Location { get; set; } = null!;
    public int ManagedByUserId { get; set; }

    [ForeignKey("ManagedByUserId")]
    public virtual User? ManagedByUser { get; set; }
}
