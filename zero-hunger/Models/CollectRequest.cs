using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace zero_hunger.Models
{
    public class CollectRequest : Helper.BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CanPreserveForMinutes { get; set; }
        public int ByRestaurantId { get; set; }
        public int AssignedEmployeeId { get; set; }
        // public bool IsCompleted { get; set; }
        // public bool IsCollected { get; set; }
        public DateTime? CollectedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        [ForeignKey("ByRestaurantId")]
        public virtual Restaurant? ByRestaurant { get; set; }
        [ForeignKey("AssignedEmployeeId")]
        public virtual User? AssignedEmployee { get; set; }

    }
}

