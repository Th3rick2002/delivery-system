using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ParcelDeliverySystem.Models;

[Table("shipment_status")]
public class ShipmentStatus
{
    [Key]
    [Column("status_id")]
    public int StatusId { get; set; }

    [Required]
    [Column("status_name")]
    public string StatusName { get; set; }

    public string Description { get; set; }

    public ICollection<Shipment> Shipments { get; set; }
}