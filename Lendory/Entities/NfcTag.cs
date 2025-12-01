using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lendory.Entities;

[Table("NFC_TAG")]
public class NfcTag
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("TAG_ID")]
    public int TagId { get; set; }

    [Required]
    [Column("UID")]
    [StringLength(64)]
    public string Uid { get; set; }

    [Column("DISPLAY_NAME")]
    public string DisplayName { get; set; }

    [Column("DESCRIPTION")]
    public string Description { get; set; }

    [Required]
    [Column("FIRST_SEEN")]
    public DateTime FirstSeen { get; set; } = DateTime.UtcNow;

    [Column("LAST_SEEN")]
    public DateTime? LastSeen { get; set; }

    [Column("ITEM_ID")]
    public int ItemId { get; set; }
    public Item Item { get; set; }

    public ICollection<NfcScan> Scans { get; set; }
}