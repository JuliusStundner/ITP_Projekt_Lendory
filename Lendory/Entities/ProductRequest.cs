using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lendory.Data;
using Microsoft.AspNetCore.Identity;

namespace Lendory.Entities;

[Table("PRODUCT_REQUEST")]
public class ProductRequest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("REQUEST_ID")]
    public int RequestId { get; set; }

    [Required]
    [Column("USER_ID")]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    
    [Required]
    [Column("PRODUCT_NAME_WANTED")]
    public string ProductNameWanted { get; set; }

    [Column("DESCRIPTION")]
    public string Description { get; set; }

    [Required]
    [Column("STATUS")]
    public string Status { get; set; } = "in_progress"; 
    // oder: requested / in_progress / accepted / rejected

    [Required]
    [Column("CREATED_AT")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required]
    [Column("UPDATED_AT")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}