using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lendory.Data;
using Microsoft.AspNetCore.Identity;

namespace Lendory.Entities;

[Table("FAVOURITE")]
public class Favourite
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column("FAVOURITE_ID")]
    public int FavouriteId { get; set; }

    [Required]
    [Column("USER_ID")]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    [Required]
    [Column("ITEM_ID")]
    public int ItemId { get; set; }
    public Item Item { get; set; }
}