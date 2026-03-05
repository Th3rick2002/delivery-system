using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcelDeliverySystem.Models;

[Table("shipment_status_history")]
public class ShipmentStatusHistory
{
    [Key]
    public int Id { get; set; }

    [Column("shipment_id")]
    public Guid ShipmentId { get; set; }

    public Shipment Shipment { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    public ShipmentStatus Status { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

    public Branch Branch { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    public User User { get; set; }

    public DateTime Date { get; set; }

    public string Notes { get; set; }
}