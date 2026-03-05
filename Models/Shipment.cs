using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDeliverySystem.Models;

[Table("shipments")]
public class Shipment
{
    [Key]
    [Column("shipment_id")]
    public Guid ShipmentId { get; set; }

    [Required]
    [Column("tracking_number")]
    public string TrackingNumber { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }
    public User User { get; set; }

    [Column("recipient_id")]
    public Guid RecipientId { get; set; }
    public Recipient Recipient { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }
    public ShipmentStatus Status { get; set; }

    [Column("branch_from")]
    public int BranchFrom { get; set; }
    public Branch OriginBranch { get; set; }

    [Column("branch_to")]
    public int BranchTo { get; set; }
    public Branch DestinationBranch { get; set; }

    public DateTime ShipmentDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public decimal Price { get; set; }

    public ICollection<Package> Packages { get; set; }
}