using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace zero_hunger.Models
{
    public class CollectRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CanPreserveForMinutes { get; set; }
        public int ByRestaurantId { get; set; }
        public int AssignedEmployeeId { get; set; }
        public bool IsCompleted { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("ByRestaurantId")]
        public virtual Restaurant ByRestaurant { get; set; } = null!;
        [ForeignKey("AssignedEmployeeId")]
        public virtual User? AssignedEmployee { get; set; }

    }
}

