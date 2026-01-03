using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lendory.Entities;

[Table("ITEM")]
public class Item
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ITEM_ID")]
    public int ItemId { get; set; }

    [Required]
    [Column("NAME")]
    [StringLength(255)]
    public string Name { get; set; }

    [Column("DESCRIPTION")]
    public string Description { get; set; }

    // FK -> Category
    [Required]
    [Column("CATEGORY_ID")]
    public int CategoryId { get; set; }
    public ItemCategory Category { get; set; }

    [Column("CONDITION")]
    public string Condition { get; set; }

    [Column("AVAILABILITY")]
    public bool Availability { get; set; } = true;

    [Required]
    [Column("DATE_ADDED")]
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    
    public string? BorrowedByUserId { get; set; }

    public string? ImageUrl { get; set; }

}
