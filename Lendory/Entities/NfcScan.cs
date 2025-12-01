using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lendory.Data;
using Microsoft.AspNetCore.Identity;

namespace Lendory.Entities;

[Table("NFC_SCAN")]
public class NfcScan
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("SCAN_ID")]
    public int ScanId { get; set; }

    [Required]
    [Column("TAG_ID")]
    public int TagId { get; set; }
    public NfcTag Tag { get; set; }

    [Column("PAYLOAD")]
    public string Payload { get; set; }

    [Column("RAW_NDEF_JSON")]
    public string RawNdefJson { get; set; }

    [Column("READER_INFO")]
    public string ReaderInfo { get; set; }

    [Required]
    [Column("SCAN_TIME")]
    public DateTime ScanTime { get; set; } = DateTime.UtcNow;
    
    [Column("USER_ID")]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

}