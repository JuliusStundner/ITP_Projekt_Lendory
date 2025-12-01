using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lendory.Entities;


[Table("CATEGORY")]
public class ItemCategory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CATEGORY_ID")]
    public int CategoryId { get; set; }

    [Required]
    [Column("NAME")]
    [StringLength(255)]
    public string Name { get; set; }

    [Column("DESCRIPTION")]
    public string Description { get; set; }

    [Required]
    [Column("HOUR_RATE")]
    public decimal HourRate { get; set; }
}