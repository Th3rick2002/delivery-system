using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ParcelDeliverySystem.Models;

[Table("recipients")]
public class Recipient
{
    [Key]
    [Column("recipient_id")]
    public Guid RecipientId { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; }

    [Required]
    [MaxLength(20)]
    public string Phone { get; set; }

    [Required]
    [MaxLength(50)]
    public string Address { get; set; }

    [Required]
    [MaxLength(20)]
    public string City { get; set; }

    [Required]
    [MaxLength(20)]
    public string Country { get; set; }

    public ICollection<Shipment> Shipments { get; set; }
}