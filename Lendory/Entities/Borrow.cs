using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lendory.Data;
using Microsoft.AspNetCore.Identity;

namespace Lendory.Entities;

[Table("BORROW")]
public class Borrow
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("BORROW_ID")]
    public int BorrowId { get; set; }
    
    [Required]
    [Column("START_AT")]
    public DateTime StartAt { get; set; }
    
    [Required]
    [Column("END_AT")]
    public DateTime EndAt { get; set; }
    
    [Required]
    [Column("TOTAL_COST")]
    public decimal TotalCost { get; set; }
    
    [Required]
    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // User FK
    [Required]
    [Column("USER_ID")]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    
    // Item FK
    [Required]
    [Column("ITEM_ID")]
    public int ItemId { get; set; }
    public Item Item { get; set; }
}